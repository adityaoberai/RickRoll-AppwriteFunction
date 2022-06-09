using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

public async Task<RuntimeResponse> Main(RuntimeRequest req, RuntimeResponse res)
{
  var payload = JsonConvert.DeserializeObject<Dictionary<string, string>>(req.Payload);
  var toPhoneNumber = payload["phoneNumber"];

  var accountSID = req.Env["TWILIO_ACCOUNTSID"];
  var authToken = req.Env["TWILIO_AUTHTOKEN"];
  var twilioPhoneNumber = req.Env["TWILIO_PHONENUMBER"];

  TwilioClient.Init(accountSID, authToken);

  var call = CallResource.Create(
                to: new PhoneNumber(toPhoneNumber),
                from: new PhoneNumber(twilioPhoneNumber),
                twiml: new Twiml("<Response><Play>https://demo.twilio.com/docs/classic.mp3</Play></Response>") 
             );
  
  return res.Json(new()
  {
    { "twilioResponse", call }
  });
}
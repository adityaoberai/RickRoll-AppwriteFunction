# 📲 Rick Roll Someone with Appwrite, Twilio, and .NET 6.0

## 🤖 Documentation

[Appwrite](https://appwrite.io) Cloud Function that [rick rolls](https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab_channel=RickAstley) a person on phone call via [Twilio](https://www.twilio.com/referral/zigWwk).

_Example input:_

This function expects a phone number in the payload in the following format: `+[Country Code][Phone Number]`

Here's an example JSON input:

```json
{
    "phoneNumber": "+919876543210"
}
```

_Example output:_

```json
{
	"twilioResponse": {
		"Sid": "CA83758d533c786be5bcf82e34b94cc8b5",
		"DateCreated": null,
		"DateUpdated": null,
		"ParentCallSid": null,
		"AccountSid": "ACe29c144db149972dbf5427bbdd0c16dd",
		"To": "\u002B919876543210",
		"ToFormatted": "\u002B919876543210",
		"From": "\u002B12184232045",
		"FromFormatted": "(218) 423-2045",
		"PhoneNumberSid": "PN671d012061f32085fcd63b046f23826f",
		"Status": {},
		"StartTime": null,
		"EndTime": null,
		"Duration": null,
		"Price": null,
		"PriceUnit": "USD",
		"Direction": "outbound-api",
		"AnsweredBy": null,
		"ApiVersion": "2010-04-01",
		"ForwardedFrom": null,
		"GroupSid": null,
		"CallerName": null,
		"QueueTime": "0",
		"TrunkSid": null,
		"Uri": "/2010-04-01/Accounts/ACe29c144db149972dbf5427bbdd0c16dd/Calls/CA83758d533c786be5bcf82e34b94cc8b5.json",
		"SubresourceUris": {
			"feedback": "/2010-04-01/Accounts/ACe29c144db149972dbf5427bbdd0c16dd/Calls/CA83758d533c786be5bcf82e34b94cc8b5/Feedback.json",
			"notifications": "/2010-04-01/Accounts/ACe29c144db149972dbf5427bbdd0c16dd/Calls/CA83758d533c786be5bcf82e34b94cc8b5/Notifications.json",
			"recordings": "/2010-04-01/Accounts/ACe29c144db149972dbf5427bbdd0c16dd/Calls/CA83758d533c786be5bcf82e34b94cc8b5/Recordings.json",
			"streams": "/2010-04-01/Accounts/ACe29c144db149972dbf5427bbdd0c16dd/Calls/CA83758d533c786be5bcf82e34b94cc8b5/Streams.json",
			"payments": "/2010-04-01/Accounts/ACe29c144db149972dbf5427bbdd0c16dd/Calls/CA83758d533c786be5bcf82e34b94cc8b5/Payments.json",
			"siprec": "/2010-04-01/Accounts/ACe29c144db149972dbf5427bbdd0c16dd/Calls/CA83758d533c786be5bcf82e34b94cc8b5/Siprec.json",
			"events": "/2010-04-01/Accounts/ACe29c144db149972dbf5427bbdd0c16dd/Calls/CA83758d533c786be5bcf82e34b94cc8b5/Events.json",
			"feedback_summaries": "/2010-04-01/Accounts/ACe29c144db149972dbf5427bbdd0c16dd/Calls/FeedbackSummary.json"
		}
	}
}
```

## 📝 Environment Variables

Go to Settings tab of your Cloud Function and add the following environment variables:

- `TWILIO_ACCOUNTSID`: Twilio Account SID
- `TWILIO_AUTHTOKEN`: Twilio Auth Token
- `TWILIO_PHONENUMBER`: Twilio Phone Number to make the call from

> ℹ️ _The Twilio Account SID and Auth Token can be obtained from your Twilio console. You can purchase a Twilio phone number using [this guide](https://support.twilio.com/hc/en-us/articles/223135247-How-to-Search-for-and-Buy-a-Twilio-Phone-Number-from-Console)._

## 🚀 Deployment

There are two ways of deploying the Appwrite function, both having the same results, but each using a different process. We highly recommend using CLI deployment to achieve the best experience.

### Using CLI

Make sure you have [Appwrite CLI](https://appwrite.io/docs/command-line#installation) installed, and you have successfully logged into your Appwrite server. To make sure Appwrite CLI is ready, you can use the command `appwrite client --debug` and it should respond with green text `✓ Success`.

Make sure you are in the same folder as your `appwrite.json` file and run `appwrite deploy function` to deploy your function. You will be prompted to select which functions you want to deploy.

### Manual using tar.gz

Manual deployment has no requirements and uses Appwrite Console to deploy the tag. First, enter the folder of your function. Then, create a tarball of the whole folder and gzip it. After creating `.tar.gz` file, visit Appwrite Console, click on the `Deploy Tag` button and switch to the `Manual` tab. There, set the `entrypoint` to `src/Index.cs`, and upload the file we just generated.

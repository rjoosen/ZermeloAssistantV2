using System;
using System.Collections.Generic;
using System.Text;

namespace ZermeloFunctionV2
{

    public class WebhookRequest
    {
        public string responseId { get; set; }
        public Queryresult queryResult { get; set; }
        public Originaldetectintentrequest originalDetectIntentRequest { get; set; }
        public string session { get; set; }
    }

    public class Queryresult
    {
        public string queryText { get; set; }
        public string action { get; set; }
        public Parameters parameters { get; set; }
        public bool allRequiredParamsPresent { get; set; }
        public Fulfillmentmessage[] fulfillmentMessages { get; set; }
        public Outputcontext[] outputContexts { get; set; }
        public Intent intent { get; set; }
        public float intentDetectionConfidence { get; set; }
        public string languageCode { get; set; }
    }

    public class Parameters
    {
        public string leerling { get; set; }
        public string[] tijd { get; set; }
        public string dayofweek { get; set; }
    }

    public class Intent
    {
        public string name { get; set; }
        public string displayName { get; set; }
    }

    public class Fulfillmentmessage
    {
        public Text text { get; set; }
    }

    public class Text
    {
        public string[] text { get; set; }
    }

    public class Outputcontext
    {
        public string name { get; set; }
        public int lifespanCount { get; set; }
        public Parameters1 parameters { get; set; }
    }

    public class Parameters1
    {
        public string leerling { get; set; }
        public string leerlingoriginal { get; set; }
        public string[] tijd { get; set; }
        public string[] tijdoriginal { get; set; }
        public string dayofweek { get; set; }
        public string dayofweekoriginal { get; set; }
    }

    public class Originaldetectintentrequest
    {
        public Payload payload { get; set; }
    }

    public class Payload
    {
    }

}

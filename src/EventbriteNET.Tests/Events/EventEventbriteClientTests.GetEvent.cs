namespace EventbriteNET.Tests.Events
{
    using System.Collections.Generic;
    using HttpApi.RequestParameters;
    using NUnit.Framework;
    using PowerAssert;

    public partial class EventEventbriteClientTests
    {
        private const string get_event =
            "{\"event\": {\"box_header_text_color\": \"005580\", \"link_color\": \"EE6600\", \"box_background_color\": \"FFFFFF\", \"box_border_color\": \"D5D5D3\", \"timezone\": \"America/Sao_Paulo\", \"organizer\": {\"url\": \"http://www.eventbrite.com/org/2485205510\", \"description\": \"\", \"long_description\": \"\", \"id\": 2485205510, \"name\": \"\"}, \"background_color\": \"FFFFFF\", \"id\": 3812465186, \"category\": \"conferences,conventions\", \"box_header_background_color\": \"EFEFEF\", \"capacity\": 0, \"num_attendee_rows\": 0, \"title\": \"\", \"confirmation_page\": \"\", \"start_date\": \"2012-08-24 08:00:00\", \"status\": \"Live\", \"description\": \"<P STYLE=\\\"text-align: justify;\\\"><FONT SIZE=\\\"3\\\">Alinhado ao crescimento e estilo inovador da Associa\\u00e7\\u00e3o, surge o primeiro evento com marca pr\\u00f3pria a</FONT><STRONG STYLE=\\\"font-size: medium;\\\">\\u00a0</STRONG><FONT SIZE=\\\"3\\\"><STRONG>1\\u00aa Confer\\u00eancia de Empreendedorismos e Inova\\u00e7\\u00e3o - Campinas Startups</STRONG>, com o tema: Gerando oportunidades atrav\\u00e9s dos modelos de inova\\u00e7\\u00e3o das </FONT><EM STYLE=\\\"font-size: medium;\\\">startups</EM><FONT SIZE=\\\"3\\\">.</FONT></P>\", \"end_date\": \"2012-08-24 20:00:00\", \"tags\": \"1\\u00aa Confer\\u00eancia de Empreendedorismos e Inova\\u00e7\\u00e3o - Campinas Startups\", \"timezone_offset\": \"GMT-0300\", \"text_color\": \"005580\", \"title_text_color\": \"\", \"tickets\": [{\"ticket\": {\"description\": \"\", \"end_date\": \"2012-08-23 10:00:00\", \"min\": 1, \"max\": 30, \"price\": \"104.09\", \"visible\": \"true\", \"start_date\": \"2012-06-01 08:00:00\", \"currency\": \"BRL\", \"type\": 0, \"id\": 14362722, \"name\": \"Startups\"}}, {\"ticket\": {\"description\": \"\", \"end_date\": \"2012-08-23 10:00:00\", \"min\": 1, \"max\": 30, \"price\": \"206.59\", \"visible\": \"true\", \"start_date\": \"2012-06-01 08:00:00\", \"currency\": \"BRL\", \"type\": 0, \"id\": 14362296, \"name\": \"Empres\\u00e1rios\"}}], \"created\": \"2012-06-25 18:23:15\", \"url\": \"http://conferenciacampinastartups.eventbrite.com\", \"box_text_color\": \"000000\", \"privacy\": \"Public\", \"modified\": \"2012-07-06 07:05:46\", \"repeats\": \"no\"}}";

        private const string get_event_with_display =
            "{\"event\": {\"box_header_text_color\": \"005580\", \"link_color\": \"EE6600\", \"box_background_color\": \"FFFFFF\", \"box_border_color\": \"D5D5D3\", \"timezone\": \"America/Sao_Paulo\", \"organizer\": {\"url\": \"http://www.eventbrite.com/org/2485205510\", \"description\": \"\", \"long_description\": \"\", \"id\": 2485205510, \"name\": \"\"}, \"background_color\": \"FFFFFF\", \"id\": 3812465186, \"category\": \"conferences,conventions\", \"box_header_background_color\": \"EFEFEF\", \"capacity\": 0, \"num_attendee_rows\": 0, \"title\": \"\", \"confirmation_page\": \"\", \"start_date\": \"2012-08-24 08:00:00\", \"status\": \"Live\", \"description\": \"<P STYLE=\\\"text-align: justify;\\\"><FONT SIZE=\\\"3\\\">Alinhado ao crescimento e estilo inovador da Associa\\u00e7\\u00e3o, surge o primeiro evento com marca pr\\u00f3pria a</FONT><STRONG STYLE=\\\"font-size: medium;\\\">\\u00a0</STRONG><FONT SIZE=\\\"3\\\"><STRONG>1\\u00aa Confer\\u00eancia de Empreendedorismos e Inova\\u00e7\\u00e3o - Campinas Startups</STRONG>, com o tema: Gerando oportunidades atrav\\u00e9s dos modelos de inova\\u00e7\\u00e3o das </FONT><EM STYLE=\\\"font-size: medium;\\\">startups</EM><FONT SIZE=\\\"3\\\">.</FONT></P>\", \"end_date\": \"2012-08-24 20:00:00\", \"tags\": \"1\\u00aa Confer\\u00eancia de Empreendedorismos e Inova\\u00e7\\u00e3o - Campinas Startups\", \"timezone_offset\": \"GMT-0300\", \"text_color\": \"005580\", \"title_text_color\": \"\", \"tickets\": [{\"ticket\": {\"description\": \"\", \"end_date\": \"2012-08-23 10:00:00\", \"min\": 1, \"max\": 30, \"price\": \"104.09\", \"visible\": \"true\", \"start_date\": \"2012-06-01 08:00:00\", \"currency\": \"BRL\", \"type\": 0, \"id\": 14362722, \"name\": \"Startups\"}}, {\"ticket\": {\"description\": \"\", \"end_date\": \"2012-08-23 10:00:00\", \"min\": 1, \"max\": 30, \"price\": \"206.59\", \"visible\": \"true\", \"start_date\": \"2012-06-01 08:00:00\", \"currency\": \"BRL\", \"type\": 0, \"id\": 14362296, \"name\": \"Empres\\u00e1rios\"}}], \"confirmation_email\": \"\", \"created\": \"2012-06-25 18:23:15\", \"url\": \"http://conferenciacampinastartups.eventbrite.com\", \"box_text_color\": \"000000\", \"privacy\": \"Public\", \"modified\": \"2012-07-06 07:05:46\", \"repeats\": \"no\"}}";


        [TestCase(get_event)]
        [TestCase(null, Category = TestCategories.Integration)]
        public void success_get_event(string responseContent)
        {
            var client = GetAsanaClient<EventbriteClient.EventEventbriteClient>(responseContent);

            var @event = client.GetEvent(new GetEventFilter
                {
                    Id = 3812465186,
                });

            PAssert.IsTrue(() => @event != null);
            PAssert.IsTrue(() => @event.Id == 3812465186);
        }

        [TestCase(get_event_with_display)]
        [TestCase(null, Category = TestCategories.Integration)]
        public void success_get_event_with_display(string responseContent)
        {
            var client = GetAsanaClient<EventbriteClient.EventEventbriteClient>(responseContent);

            var @event = client.GetEvent(new GetEventFilter
                {
                    Id = 3812465186,
                    EventDisplayFields = new List<GetEventDisplayFields>
                        {
                            GetEventDisplayFields.confirmation_page,
                            GetEventDisplayFields.confirmation_email,
                        },
                });

            PAssert.IsTrue(() => @event != null);
            PAssert.IsTrue(() => @event.Id == 3812465186);
            PAssert.IsTrue(() => @event.ConfirmationEmail != null);
            PAssert.IsTrue(() => @event.ConfirmationPage != null);
        }
    }
}
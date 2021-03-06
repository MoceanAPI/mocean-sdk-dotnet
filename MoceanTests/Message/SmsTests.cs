﻿using Mocean.Exceptions;
using MoceanTests;
using NUnit.Framework;
using System.Net.Http;

namespace Mocean.Message.Tests
{
    [TestFixture]
    public class SmsTests
    {
        [Test]
        public void SmsRequestTest()
        {
            var smsRequest = new SmsRequest
            {
                mocean_alt_dcs = "test altdcs",
                mocean_charset = "test charset",
                mocean_coding = "test coding",
                mocean_dlr_mask = "test dlrmask",
                mocean_dlr_url = "test dlrurl",
                mocean_from = "test from",
                mocean_mclass = "test mclass",
                mocean_schedule = "test schedule",
                mocean_text = "test text",
                mocean_to = "test to",
                mocean_udh = "test udh",
                mocean_validity = "test validity",
                mocean_resp_format = "json"
            };

            Assert.IsNotNull(smsRequest.mocean_alt_dcs);
            Assert.AreEqual(smsRequest.mocean_alt_dcs, "test altdcs");
            Assert.IsNotNull(smsRequest.mocean_charset);
            Assert.AreEqual(smsRequest.mocean_charset, "test charset");
            Assert.IsNotNull(smsRequest.mocean_coding);
            Assert.AreEqual(smsRequest.mocean_coding, "test coding");
            Assert.IsNotNull(smsRequest.mocean_dlr_mask);
            Assert.AreEqual(smsRequest.mocean_dlr_mask, "test dlrmask");
            Assert.IsNotNull(smsRequest.mocean_dlr_url);
            Assert.AreEqual(smsRequest.mocean_dlr_url, "test dlrurl");
            Assert.IsNotNull(smsRequest.mocean_from);
            Assert.AreEqual(smsRequest.mocean_from, "test from");
            Assert.IsNotNull(smsRequest.mocean_mclass);
            Assert.AreEqual(smsRequest.mocean_mclass, "test mclass");
            Assert.IsNotNull(smsRequest.mocean_schedule);
            Assert.AreEqual(smsRequest.mocean_schedule, "test schedule");
            Assert.IsNotNull(smsRequest.mocean_text);
            Assert.AreEqual(smsRequest.mocean_text, "test text");
            Assert.IsNotNull(smsRequest.mocean_to);
            Assert.AreEqual(smsRequest.mocean_to, "test to");
            Assert.IsNotNull(smsRequest.mocean_udh);
            Assert.AreEqual(smsRequest.mocean_udh, "test udh");
            Assert.IsNotNull(smsRequest.mocean_validity);
            Assert.AreEqual(smsRequest.mocean_validity, "test validity");
            Assert.IsNotNull(smsRequest.mocean_resp_format);
            Assert.AreEqual(smsRequest.mocean_resp_format, "json");

            smsRequest = new SmsRequest();
            Assert.IsNull(smsRequest.mocean_alt_dcs);
            Assert.IsNull(smsRequest.mocean_charset);
            Assert.IsNull(smsRequest.mocean_coding);
            Assert.IsNull(smsRequest.mocean_dlr_mask);
            Assert.IsNull(smsRequest.mocean_dlr_url);
            Assert.IsNull(smsRequest.mocean_from);
            Assert.IsNull(smsRequest.mocean_mclass);
            Assert.IsNull(smsRequest.mocean_schedule);
            Assert.IsNull(smsRequest.mocean_text);
            Assert.IsNull(smsRequest.mocean_to);
            Assert.IsNull(smsRequest.mocean_udh);
            Assert.IsNull(smsRequest.mocean_validity);
            Assert.IsNull(smsRequest.mocean_resp_format);
            smsRequest.mocean_alt_dcs = "test altdcs";
            Assert.AreEqual(smsRequest.mocean_alt_dcs, "test altdcs");
            smsRequest.mocean_charset = "test charset";
            Assert.AreEqual(smsRequest.mocean_charset, "test charset");
            smsRequest.mocean_coding = "test coding";
            Assert.AreEqual(smsRequest.mocean_coding, "test coding");
            smsRequest.mocean_dlr_mask = "test dlrmask";
            Assert.AreEqual(smsRequest.mocean_dlr_mask, "test dlrmask");
            smsRequest.mocean_dlr_url = "test dlrurl";
            Assert.AreEqual(smsRequest.mocean_dlr_url, "test dlrurl");
            smsRequest.mocean_from = "test from";
            Assert.AreEqual(smsRequest.mocean_from, "test from");
            smsRequest.mocean_mclass = "test mclass";
            Assert.AreEqual(smsRequest.mocean_mclass, "test mclass");
            smsRequest.mocean_schedule = "test schedule";
            Assert.AreEqual(smsRequest.mocean_schedule, "test schedule");
            smsRequest.mocean_text = "test text";
            Assert.AreEqual(smsRequest.mocean_text, "test text");
            smsRequest.mocean_to = "test to";
            Assert.AreEqual(smsRequest.mocean_to, "test to");
            smsRequest.mocean_udh = "test udh";
            Assert.AreEqual(smsRequest.mocean_udh, "test udh");
            smsRequest.mocean_validity = "test validity";
            Assert.AreEqual(smsRequest.mocean_validity, "test validity");
            smsRequest.mocean_resp_format = "json";
            Assert.AreEqual(smsRequest.mocean_resp_format, "json");
        }

        [Test]
        public void RequiredFieldNotSetTest()
        {
            var apiRequestMock = new ApiRequest(
                TestingUtils.GetMockHttpClient((HttpRequestMessage httpRequest) =>
                {
                    return TestingUtils.GetResponse("message.json");
                })
            );

            var mocean = TestingUtils.GetClientObj(apiRequestMock);
            Assert.Throws<RequiredFieldException>(() =>
            {
                mocean.Sms.Send(new SmsRequest());
            });

        }

        [Test]
        public void JsonSendTest()
        {
            var apiRequestMock = new ApiRequest(
                TestingUtils.GetMockHttpClient((HttpRequestMessage httpRequest) =>
                {
                    Assert.AreEqual(HttpMethod.Post, httpRequest.Method);
                    Assert.AreEqual(TestingUtils.GetTestUri("/sms"), httpRequest.RequestUri.LocalPath);
                    return TestingUtils.GetResponse("message.json");
                })
            );

            var mocean = TestingUtils.GetClientObj(apiRequestMock);
            var res = mocean.Sms.Send(new SmsRequest
            {
                mocean_from = "testing from",
                mocean_text = "testing text",
                mocean_to = "testing to"
            });
            Assert.AreEqual(res.ToString(), TestingUtils.ReadFile("message.json"));
            TestObject(res);
        }

        [Test]
        public void XmlSendTest()
        {
            var apiRequestMock = new ApiRequest(
                TestingUtils.GetMockHttpClient((HttpRequestMessage httpRequest) =>
                {
                    Assert.AreEqual(HttpMethod.Post, httpRequest.Method);
                    Assert.AreEqual(TestingUtils.GetTestUri("/sms", "1"), httpRequest.RequestUri.LocalPath);
                    return TestingUtils.GetResponse("message.xml");
                })
            );

            apiRequestMock.ApiRequestConfig.Version = "1";
            var mocean = TestingUtils.GetClientObj(apiRequestMock);
            var res = mocean.Sms.Send(new SmsRequest
            {
                mocean_from = "testing from",
                mocean_text = "testing text",
                mocean_to = "testing to",
                mocean_resp_format = "xml"
            });
            Assert.AreEqual(res.ToString(), TestingUtils.ReadFile("message.xml"));
            TestObject(res);

            //V2 Test
            apiRequestMock = new ApiRequest(
                TestingUtils.GetMockHttpClient((HttpRequestMessage httpRequest) =>
                {
                    Assert.AreEqual(HttpMethod.Post, httpRequest.Method);
                    Assert.AreEqual(TestingUtils.GetTestUri("/sms"), httpRequest.RequestUri.LocalPath);
                    return TestingUtils.GetResponse("message_v2.xml");
                })
            );

            apiRequestMock.ApiRequestConfig.Version = "2";
            mocean = TestingUtils.GetClientObj(apiRequestMock);
            res = mocean.Sms.Send(new SmsRequest
            {
                mocean_from = "testing from",
                mocean_text = "testing text",
                mocean_to = "testing to",
                mocean_resp_format = "xml"
            });
            Assert.AreEqual(res.ToString(), TestingUtils.ReadFile("message_v2.xml"));
            TestObject(res);
        }

        private static void TestObject(SmsResponse smsResponse)
        {
            Assert.AreEqual(smsResponse.Messages[0].Status, "0");
            Assert.AreEqual(smsResponse.Messages[0].Receiver, "60123456789");
            Assert.AreEqual(smsResponse.Messages[0].MsgId, "CPASS_restapi_C0000002737000000.0001");
        }
    }
}
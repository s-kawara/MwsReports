using MarketplaceWebService;
using MarketplaceWebService.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace MwsReports
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Request Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequestReport_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            MarketplaceWebServiceClient client = new MarketplaceWebServiceClient(
                                                             AccessKeyId,
                                                             SecretKeyId,
                                                             ApplicationName,
                                                             ApplicationVersion,
                                                             config);
            RequestReportRequest request = new RequestReportRequest();
            request.Merchant = SellerId;
            request.MarketplaceIdList = new IdList();
            request.MarketplaceIdList.Id = new List<string>(new string[] { MarketplaceId });
            request.ReportType = "_GET_FLAT_FILE_OPEN_LISTINGS_DATA_";
            request.MWSAuthToken = MWSAuthToken;

            RequestReportResponse response = client.RequestReport(request);
            if (response.IsSetRequestReportResult())
            {
                RequestReportResult requestReportResult = response.RequestReportResult;
                ReportRequestInfo reportRequestInfo = requestReportResult.ReportRequestInfo;
                if (reportRequestInfo.IsSetReportProcessingStatus())
                {
                    strbuff = "Request ID：" + reportRequestInfo.ReportRequestId;
                }
            }
            txtRequestReport.Text = strbuff;
        }

        /// <summary>
        /// Get Report Request List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetReportRequestList_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            MarketplaceWebServiceClient client = new MarketplaceWebServiceClient(
                                                             AccessKeyId,
                                                             SecretKeyId,
                                                             ApplicationName,
                                                             ApplicationVersion,
                                                             config);
            GetReportRequestListRequest request = new GetReportRequestListRequest();
            request.Merchant = SellerId;
            request.MWSAuthToken = MWSAuthToken;

            GetReportRequestListResponse response = client.GetReportRequestList(request);
            if (response.IsSetGetReportRequestListResult())
            {
                GetReportRequestListResult getReportRequestListResult = response.GetReportRequestListResult;
                List<ReportRequestInfo> reportRequestInfoList = getReportRequestListResult.ReportRequestInfo;
                foreach (ReportRequestInfo reportRequestInfo in reportRequestInfoList)
                {
                    strbuff += "Report ID：" + reportRequestInfo.ReportRequestId + " Result：" + reportRequestInfo.ReportProcessingStatus + System.Environment.NewLine;
                }
            }
            txtGetReportRequestList.Text = strbuff;
        }


        /// <summary>
        /// Get Report List By Next List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetReportRequestListByNext_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            MarketplaceWebServiceClient client = new MarketplaceWebServiceClient(
                                                             AccessKeyId,
                                                             SecretKeyId,
                                                             ApplicationName,
                                                             ApplicationVersion,
                                                             config);
            GetReportRequestListRequest request = new GetReportRequestListRequest();
            request.Merchant = SellerId;
            request.MWSAuthToken = MWSAuthToken;

            GetReportRequestListResponse response = client.GetReportRequestList(request);
            if (response.IsSetGetReportRequestListResult())
            {
                GetReportRequestListResult getReportRequestListResult = response.GetReportRequestListResult;
                if (getReportRequestListResult.HasNext)
                {
                    GetReportRequestListByNextTokenRequest request1 = new GetReportRequestListByNextTokenRequest();
                    request1.Merchant = SellerId;
                    request1.NextToken = getReportRequestListResult.NextToken;
                    request1.MWSAuthToken = MWSAuthToken;

                    GetReportRequestListByNextTokenResponse response1 = client.GetReportRequestListByNextToken(request1);
                    if (response1.IsSetGetReportRequestListByNextTokenResult())
                    {
                        GetReportRequestListByNextTokenResult getReportRequestListByNextTokenResult = response1.GetReportRequestListByNextTokenResult;
                        List<ReportRequestInfo> reportRequestInfoList = getReportRequestListByNextTokenResult.ReportRequestInfo;
                        foreach (ReportRequestInfo reportRequestInfo in reportRequestInfoList)
                        {
                            strbuff += "Report ID：" + reportRequestInfo.ReportRequestId + " Result：" + reportRequestInfo.ReportProcessingStatus + System.Environment.NewLine;
                        }
                    }
                }
                txtGetReportRequestListByNextToken.Text = strbuff;
            }
        }


        /// <summary>
        /// Get Report Count
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetReportRequestCount_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            MarketplaceWebServiceClient client = new MarketplaceWebServiceClient(
                                                             AccessKeyId,
                                                             SecretKeyId,
                                                             ApplicationName,
                                                             ApplicationVersion,
                                                             config);
            GetReportRequestCountRequest request = new GetReportRequestCountRequest();
            request.Merchant = SellerId;
            request.MWSAuthToken = MWSAuthToken;
            GetReportRequestCountResponse response = client.GetReportRequestCount(request);
            if (response.IsSetGetReportRequestCountResult())
            {
                GetReportRequestCountResult getReportRequestCountResult = response.GetReportRequestCountResult;
                if (getReportRequestCountResult.IsSetCount())
                {
                    strbuff = "Report Record Count：" + getReportRequestCountResult.Count;
                }
            }
            txtGetReportRequestCount.Text = strbuff;
        }

        /// <summary>
        /// Cancel Report 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelReportRequests_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            MarketplaceWebServiceClient client = new MarketplaceWebServiceClient(
                                                             AccessKeyId,
                                                             SecretKeyId,
                                                             ApplicationName,
                                                             ApplicationVersion,
                                                             config);
            CancelReportRequestsRequest request = new CancelReportRequestsRequest();
            // 引数設定
            request.Merchant = SellerId;
            request.ReportRequestIdList = new IdList();
            request.ReportRequestIdList.Id = new List<string>(new string[] { txtCancelReportRequestsSearch.Text });
            request.MWSAuthToken = MWSAuthToken;
            CancelReportRequestsResponse response = client.CancelReportRequests(request);
            if (response.IsSetCancelReportRequestsResult())
            {
                CancelReportRequestsResult cancelReportRequestsResult = response.CancelReportRequestsResult;
                List<ReportRequestInfo> reportRequestInfoList = cancelReportRequestsResult.ReportRequestInfo;
                foreach (ReportRequestInfo reportRequestInfo in reportRequestInfoList)
                {
                    strbuff = "Report cancel Result：" + reportRequestInfo.ReportProcessingStatus;
                }
            }
            txtCancelReportRequests.Text = strbuff;
        }

        /// <summary>
        /// Get Report List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetRportList_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            MarketplaceWebServiceClient client = new MarketplaceWebServiceClient(
                                                             AccessKeyId,
                                                             SecretKeyId,
                                                             ApplicationName,
                                                             ApplicationVersion,
                                                             config);
            GetReportListRequest request = new GetReportListRequest();
            request.Merchant = SellerId;
            request.MWSAuthToken = MWSAuthToken;
            GetReportListResponse response = client.GetReportList(request);
            if (response.IsSetGetReportListResult())
            {
                GetReportListResult getReportListResult = response.GetReportListResult;
                List<ReportInfo> reportInfoList = getReportListResult.ReportInfo;
                foreach (ReportInfo reportInfo in reportInfoList)
                {
                    strbuff += "Report ID：" + reportInfo.ReportId + System.Environment.NewLine;
                }
            }
            txtGetRportList.Text = strbuff;
        }

        /// <summary>
        /// Get Next Report List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetReportListByNextToken_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            MarketplaceWebServiceClient client = new MarketplaceWebServiceClient(
                                                             AccessKeyId,
                                                             SecretKeyId,
                                                             ApplicationName,
                                                             ApplicationVersion,
                                                             config);
            GetReportListRequest request = new GetReportListRequest();
            request.Merchant = SellerId;
            request.MWSAuthToken = MWSAuthToken;
            GetReportListResponse response = client.GetReportList(request);
            if (response.IsSetGetReportListResult())
            {
                GetReportListResult getReportListResult = response.GetReportListResult;
                if (getReportListResult.HasNext)
                {
                    GetReportListByNextTokenRequest request1 = new GetReportListByNextTokenRequest();
                    request1.Merchant = SellerId;
                    request1.NextToken = getReportListResult.NextToken;
                    request1.MWSAuthToken = MWSAuthToken;

                    GetReportListByNextTokenResponse response1 = client.GetReportListByNextToken(request1);
                    if (response1.IsSetGetReportListByNextTokenResult())
                    {
                        GetReportListByNextTokenResult getReportListByNextTokenResult = response1.GetReportListByNextTokenResult;
                        List<ReportInfo> reportInfoList = getReportListByNextTokenResult.ReportInfo;
                        foreach (ReportInfo reportInfo in reportInfoList)
                        {
                            strbuff += "Report ID：" + reportInfo.ReportId + System.Environment.NewLine;
                        }
                    }
                }
                txtGetReportListByNextToken.Text = strbuff;
            }

        }

        /// <summary>
        /// Get Report Count
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetReportCount_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            MarketplaceWebServiceClient client = new MarketplaceWebServiceClient(
                                                             AccessKeyId,
                                                             SecretKeyId,
                                                             ApplicationName,
                                                             ApplicationVersion,
                                                             config);
            GetReportCountRequest request = new GetReportCountRequest();
            request.Merchant = SellerId;
            request.MWSAuthToken = MWSAuthToken;
            // レポート数取得
            GetReportCountResponse response = client.GetReportCount(request);
            if (response.IsSetGetReportCountResult())
            {
                GetReportCountResult getReportCountResult = response.GetReportCountResult;
                if (getReportCountResult.IsSetCount())
                {
                    strbuff = "Report Record Count：" + getReportCountResult.Count;
                }
            }
            txtGetReportCount.Text = strbuff;
        }

        /// <summary>
        /// Get Report by ReportID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetReport_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            MarketplaceWebServiceClient client = new MarketplaceWebServiceClient(
                                                             AccessKeyId,
                                                             SecretKeyId,
                                                             ApplicationName,
                                                             ApplicationVersion,
                                                             config);
            GetReportRequest request = new GetReportRequest();
            request.Merchant = SellerId;
            request.ReportId = txtGetReportSearch.Text;
            request.Report = System.IO.File.Open(@"C:\tmp\report.xml", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
            // レポート取得実行
            GetReportResponse response = client.GetReport(request);
            if (response.IsSetGetReportResult())
            {
                strbuff = "Process Finish.";
            }
            else
            {
                strbuff = "Process Error.";
            }
            txtGetReport.Text = strbuff;
        }

        /// <summary>
        /// Manage Report Schedule
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManageRportSchedule_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            MarketplaceWebServiceClient client = new MarketplaceWebServiceClient(
                                                             AccessKeyId,
                                                             SecretKeyId,
                                                             ApplicationName,
                                                             ApplicationVersion,
                                                             config);
            ManageReportScheduleRequest request = new ManageReportScheduleRequest();
            request.Merchant = SellerId;
            request.MWSAuthToken = MWSAuthToken;
            request.ReportType = "_GET_FLAT_FILE_OPEN_LISTINGS_DATA_";
            request.Schedule = "_72_HOURS_";
            ManageReportScheduleResponse response = client.ManageReportSchedule(request);
            if (response.IsSetManageReportScheduleResult())
            {
                strbuff = "Schedule process finish.";
            }
            else
            {
                strbuff = "Schedule process error.";
            }
            txtManageRportSchedule.Text = strbuff;
        }

        /// <summary>
        /// Get Manage Report List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetReportScheduleList_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            MarketplaceWebServiceClient client = new MarketplaceWebServiceClient(
                                                             AccessKeyId,
                                                             SecretKeyId,
                                                             ApplicationName,
                                                             ApplicationVersion,
                                                             config);
            GetReportScheduleListRequest request = new GetReportScheduleListRequest();
            request.Merchant = SellerId;
            request.MWSAuthToken = MWSAuthToken;
            GetReportScheduleListResponse response = client.GetReportScheduleList(request);
            if (response.IsSetGetReportScheduleListResult())
            {
                GetReportScheduleListResult getReportScheduleListResult = response.GetReportScheduleListResult;
                List<ReportSchedule> reportScheduleList = getReportScheduleListResult.ReportSchedule;
                foreach (ReportSchedule reportSchedule in reportScheduleList)
                {
                    strbuff += "Report Type：" + reportSchedule.ReportType + System.Environment.NewLine;
                }
            }
            txtGetReportScheduleList.Text = strbuff;
        }

        /// <summary>
        /// Get Next Manage Report Schedule
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetReportScheduleListByNextToken_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            MarketplaceWebServiceClient client = new MarketplaceWebServiceClient(
                                                             AccessKeyId,
                                                             SecretKeyId,
                                                             ApplicationName,
                                                             ApplicationVersion,
                                                             config);
            GetReportScheduleListRequest request = new GetReportScheduleListRequest();
            request.Merchant = SellerId;
            request.MWSAuthToken = MWSAuthToken;
            GetReportScheduleListResponse response = client.GetReportScheduleList(request);
            if (response.IsSetGetReportScheduleListResult())
            {
                GetReportScheduleListResult getReportScheduleListResult = response.GetReportScheduleListResult;
                if (getReportScheduleListResult.HasNext)
                {
                    GetReportScheduleListByNextTokenRequest request1 = new GetReportScheduleListByNextTokenRequest();
                    request1.Merchant = SellerId;
                    request1.NextToken = getReportScheduleListResult.NextToken;
                    request1.MWSAuthToken = MWSAuthToken;
                    GetReportScheduleListByNextTokenResponse response1 = client.GetReportScheduleListByNextToken(request1);
                    if (response1.IsSetGetReportScheduleListByNextTokenResult())
                    {

                        GetReportScheduleListByNextTokenResult getReportScheduleListByNextTokenResult = response1.GetReportScheduleListByNextTokenResult;
                        List<ReportSchedule> reportScheduleList = getReportScheduleListByNextTokenResult.ReportSchedule;
                        foreach (ReportSchedule reportSchedule in reportScheduleList)
                        {
                            strbuff += "Report Type：" + reportSchedule.ReportType + System.Environment.NewLine;
                        }
                    }
                }
                txtGetReportScheduleListByNextToken.Text = strbuff;
            }
        }

        /// <summary>
        /// Get Report Schedule Count
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetReportScheduleCount_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            MarketplaceWebServiceClient client = new MarketplaceWebServiceClient(
                                                             AccessKeyId,
                                                             SecretKeyId,
                                                             ApplicationName,
                                                             ApplicationVersion,
                                                             config);
            GetReportScheduleCountRequest request = new GetReportScheduleCountRequest();
            request.Merchant = SellerId;
            request.MWSAuthToken = MWSAuthToken;
            GetReportScheduleCountResponse response = client.GetReportScheduleCount(request);
            if (response.IsSetGetReportScheduleCountResult())
            {
                GetReportScheduleCountResult getReportScheduleCountResult = response.GetReportScheduleCountResult;
                if (getReportScheduleCountResult.IsSetCount())
                {
                    strbuff = "Schedule Report Record Count：" + getReportScheduleCountResult.Count;
                }
            }
            txtGetReportScheduleCount.Text = strbuff;
        }

        /// <summary>
        /// Update Report Acknowledge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateReportAcknowledgements_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            MarketplaceWebServiceClient client = new MarketplaceWebServiceClient(
                                                             AccessKeyId,
                                                             SecretKeyId,
                                                             ApplicationName,
                                                             ApplicationVersion,
                                                             config);
            UpdateReportAcknowledgementsRequest request = new UpdateReportAcknowledgementsRequest();
            // 引数設定
            request.Merchant = SellerId;
            request.WithReportIdList(new IdList().WithId(txtUpdateReportAcknowledgementsSearch.Text));
            // 更新処理実行
            UpdateReportAcknowledgementsResponse response = client.UpdateReportAcknowledgements(request);
            if (response.IsSetUpdateReportAcknowledgementsResult())
            {
                strbuff = "Update process finish";
            }
            else
            {
                strbuff = "Update process error";
            }
            txtUpdateReportAcknowledgements.Text = strbuff;
        }
    }
}

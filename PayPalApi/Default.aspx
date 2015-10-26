<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PayPalApi.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>TEST PAYPAL</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="jumbotron">
            <h1 class="text-center">Test PayPal Refund</h1>
        </div>
        <div class="row">
            <div class="col-xs-3 col-md-3">
                <div class="panel-group" id="collapse">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#collapse" href="#collapse-one">
                                    Product's Category
                                </a>
                            </h4>
                        </div>
                        <div id="collapse-one" class="panel-collapse collapse">
                            <div class="panel-body">
                                <ul>
                                    <li><a href="#">English to Japan</a></li>
                                    <li><a href="#">Japan to English</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#collapse" href="#collapse-two">
                                    FAQs
                                </a>
                            </h4>
                        </div>
                        <div id="collapse-two" class="panel-collapse collapse">
                            <div class="panel-body">
                                <ul>
                                    <li><a href="#">Lowest Price</a></li>
                                    <li><a href="#">Cancellation Policy</a></li>
                                    <li><a href="#">Payment</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#collapse" href="#collapse-three">
                                    Contact Us
                                </a>
                            </h4>
                        </div>
                        <div id="collapse-three" class="panel-collapse collapse">
                            <div class="panel-body">
                                Tokyo head office Second Mori Building 4F, Hamamatsucho 2-1-3, Minato-ku, Tokyo 105-0013
                                <br />Tel: 81-3-5733-4264
                                <br />Fax: 81-3-3433-3320
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a href="History.aspx">Transaction History</a>
                            </h4>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-9 col-md-9">
                <h3 class="text-center">Payment Method</h3>
                <!-- Tabs -->
                <ul class="nav nav-tabs" role="tablist">
                    <li class="active"><a href="#paypal" role="tab" data-toggle="tab">PayPal</a></li>
                    <li><a href="#cash" role="tab" data-toggle="tab">Cash</a></li>
                </ul>
                <!-- Tab Content -->
                <div class="tab-content">
                    <div class="active tab-pane fade in" id="paypal">
                        <br />
                        <form runat="server">
                            <div class="radio">
                                <label>
                                    <input type="radio" name="optionsRadios" id="optionsRadios1" value="option1">
                                    $10
                                </label>
                            </div>
                            <div class="radio">
                                <label>
                                    <input type="radio" name="optionsRadios" id="optionsRadios2" value="option2">
                                    $30
                                </label>
                            </div>
                            <div class="radio">
                                <label>
                                    <input type="radio" name="optionsRadios" id="optionsRadios3" value="option3">
                                    $50
                                </label>
                            </div>
                            <asp:Button CssClass="btn btn-primary" ID="Pay" runat="server" Text="Pay" OnClick="Pay_Click" />
                        </form>
                    </div>
                    <div class="tab-pane fade" id="cash">
                        <br />
                        <div>
                            Sorry, We are not accept cash for now.
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="/Scripts/jquery-2.1.4.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
</body>
</html>

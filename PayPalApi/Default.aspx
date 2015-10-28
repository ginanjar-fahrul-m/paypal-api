<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PayPalApi.Default" MasterPageFile="~/MasterPage.Master"%>


<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="jumbotron">
        <h1 class="text-center"><%= GetGlobalResourceObject("Resources","header") %></h1>
    </div>
    <div class="row">
        <div class="col-xs-3 col-md-3">
            <div class="panel-group" id="collapse">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#collapse" href="#collapse-one">
                                <%= GetGlobalResourceObject("Resources","mnCategory") %>
                            </a>
                        </h4>
                    </div>
                    <div id="collapse-one" class="panel-collapse collapse">
                        <div class="panel-body">
                            <ul>
                                <li><a href="#"><%= GetGlobalResourceObject("Resources","catEngToJpn") %></a></li>
                                <li><a href="#"><%= GetGlobalResourceObject("Resources","catJpnToEng") %></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#collapse" href="#collapse-two">
                                <%= GetGlobalResourceObject("Resources","mnFaq") %>
                            </a>
                        </h4>
                    </div>
                    <div id="collapse-two" class="panel-collapse collapse">
                        <div class="panel-body">
                            <ul>
                                <li><a href="#"><%= GetGlobalResourceObject("Resources","txt1") %></a></li>
                                <li><a href="#"><%= GetGlobalResourceObject("Resources","txt2") %></a></li>
                                <li><a href="#"><%= GetGlobalResourceObject("Resources","txt3") %></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#collapse" href="#collapse-three">
                                <%= GetGlobalResourceObject("Resources","mnContact") %>
                            </a>
                        </h4>
                    </div>
                    <div id="collapse-three" class="panel-collapse collapse">
                        <div class="panel-body">
                            <%= GetGlobalResourceObject("Resources","mnCompany") %>
                            <br /><%= GetGlobalResourceObject("Resources","txtTel") %>
                            <br /><%= GetGlobalResourceObject("Resources","txtFax") %>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a href="History.aspx"><%= GetGlobalResourceObject("Resources","mnTrans") %></a>
                        </h4>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xs-9 col-md-9">
            <h3 class="text-center"><%= GetGlobalResourceObject("Resources","headerMethod") %></h3>
            <!-- Tabs -->
            <ul class="nav nav-tabs" role="tablist">
                <li class="active"><a href="#paypal" role="tab" data-toggle="tab"><%= GetGlobalResourceObject("Resources","tabPaypal") %></a></li>
                <li><a href="#cash" role="tab" data-toggle="tab"><%= GetGlobalResourceObject("Resources","tabCash") %></a></li>
            </ul>
            <!-- Tab Content -->
            <div class="tab-content">
                <div class="active tab-pane fade in" id="paypal">
                    <br />
                    <div>                           
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                            <asp:ListItem Text=" $10" Value="10"></asp:ListItem>
                            <asp:ListItem Text=" $30" Value="30"></asp:ListItem>
                            <asp:ListItem Text=" $50" Value="50"></asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        <asp:Button CssClass="btn btn-primary" ID="Pay" runat="server" Text="Pay" OnClick="Pay_Click" />                
                    </div>
                </div>
                <div class="tab-pane fade" id="cash">
                    <br />
                    <div>
                        <%= GetGlobalResourceObject("Resources","msg1") %>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <script src="/Scripts/jquery-2.1.4.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
</asp:Content>

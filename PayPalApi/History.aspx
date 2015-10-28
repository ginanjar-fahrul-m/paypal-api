<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="PayPalApi.History" MasterPageFile="~/MasterPage.Master"%>

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
			<% if (!string.IsNullOrEmpty(this.message))
				{ %>
			<div class="alert alert-success">
			  <strong><%= GetGlobalResourceObject("Resources","msg2") %></strong> <%= this.message %>
			</div>
			<%      this.message = null;
				} %>
			<% if (string.IsNullOrEmpty(this.paymentid))
				{ %>
			<h3 class="text-center"><%= GetGlobalResourceObject("Resources","txtTrans") %></h3>
			<br />
			<dl>
				<% 
					var payments = this.history.GetEnumerator();
					while (payments.MoveNext())
					{
						var transactions = payments.Current.transactions.GetEnumerator();
						
						while (transactions.MoveNext())
						{
							var desc = transactions.Current.description;
							var amount = transactions.Current.amount.currency + " " + transactions.Current.amount.total;
							var invoice = transactions.Current.invoice_number;
				%>
				<dt><%= "Invoice number: " + invoice + " " + desc + "(" + amount + ")" %></dt>
				<dd><a class="btn btn-warning" href="History.aspx?paymentid=<%= payments.Current.id %>" role="button">Refund</a></dd>
				<br />
				<% 
						}
					}
				%>
			</dl>
			<% } %>
		</div>
	</div>
    <script src="/Scripts/jquery-2.1.4.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
</asp:Content>

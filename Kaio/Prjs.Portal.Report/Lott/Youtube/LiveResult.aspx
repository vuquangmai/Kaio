<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LiveResult.aspx.vb" Inherits="Prjs.Portal.Report.LottYtLiveResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Live Lottery</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-1.7.1.min.js"></script>
    <link rel="stylesheet" href="compiled/fclock.css" />
    <script type="text/javascript" src="compiled/flipclock.js"></script>

    <style type="text/css">
        div.table_time {
            display: table;
            width: 100%;
            background-color: #fff;
            border-collapse: collapse;
            border: 0px;
        }

        div.row_time {
            display: table-row;
            margin: 0;
        }

        div.cell_time {
            display: table-cell;
            border: 0px;
            text-align: center;
            width: 80%;
            padding: 5px;
        }

        div.table {
            display: table;
            width: 100%;
            background-color: #fff;
            border-collapse: collapse;
            border: 1px solid #99CCFF;
        }

        div.row {
            display: table-row;
        }

        div.cell {
            display: table-cell;
            border: 1px solid #99CCFF;
            text-align: center;
        }

        div.cell_prize {
            display: table-cell;
            border: 1px solid #99CCFF;
            text-align: right;
            width: 20%;
            padding-top: 5px;
            padding-bottom: 5px;
        }

        div.table_2 {
            display: table;
            width: 100%;
            background-color: #fff;
            border-collapse: collapse;
            border: 0px;
        }

        div.row_2 {
            display: table-row;
        }

        div.cell_21 {
            display: table-cell;
            border-right: 1px solid #99CCFF;
            text-align: center;
            width: 50%;
            padding-top: 5px;
            padding-bottom: 5px;
        }

        div.cell_22 {
            display: table-cell;
            border: 0px;
            text-align: center;
            width: 50%;
            padding-top: 5px;
            padding-bottom: 5px;
        }

        div.table_3 {
            display: table;
            width: 100%;
            background-color: #fff;
            border-collapse: collapse;
            border: 0px;
        }

        div.row_3 {
            display: table-row;
        }

        div.cell_31 {
            display: table-cell;
            border-right: 1px solid #99CCFF;
            border-bottom: 1px solid #99CCFF;
            text-align: center;
            width: 33%;
            padding-top: 5px;
            padding-bottom: 5px;
        }

        div.cell_32 {
            display: table-cell;
            border: 0px;
            text-align: center;
            border-right: 1px solid #99CCFF;
            border-bottom: 1px solid #99CCFF;
            width: 33%;
            padding-top: 5px;
            padding-bottom: 5px;
        }

        div.cell_33 {
            display: table-cell;
            border: 0px;
            text-align: center;
            border-bottom: 1px solid #99CCFF;
            padding-top: 5px;
            padding-bottom: 5px;
        }

        div.cell_34 {
            display: table-cell;
            border: 0px;
            text-align: center;
            border-right: 1px solid #99CCFF;
            width: 33%;
            padding-top: 5px;
            padding-bottom: 5px;
        }

        div.cell_35 {
            display: table-cell;
            border: 0px;
            text-align: center;
            border-right: 1px solid #99CCFF;
            width: 33%;
            padding-top: 5px;
            padding-bottom: 5px;
        }

        div.cell_36 {
            display: table-cell;
            border: 0px;
            text-align: center;
            padding-top: 5px;
            padding-bottom: 5px;
        }

        div.table_4 {
            display: table;
            width: 100%;
            background-color: #fff;
            border-collapse: collapse;
            border: 0px;
        }

        div.row_4 {
            display: table-row;
        }

        div.cell_41 {
            display: table-cell;
            border-right: 1px solid #99CCFF;
            text-align: center;
            width: 25%;
            padding-top: 5px;
            padding-bottom: 5px;
        }

        div.cell_42 {
            display: table-cell;
            border: 0px;
            text-align: center;
            width: 25%;
            padding-top: 5px;
            padding-bottom: 5px;
        }

        div.cell_43 {
            display: table-cell;
            border: 0px;
            text-align: center;
            width: 25%;
            padding-top: 5px;
            padding-bottom: 5px;
        }

        div.cell_43 {
            display: table-cell;
            border: 0px;
            text-align: center;
            width: 25%;
            padding-top: 5px;
            padding-bottom: 5px;
        }
    </style>
    <!--Load Result -->
    <script type="text/javascript">
        $(document).ready(function () {

            window.setInterval(function () {
                var temp = 1;
                $.ajax({
                    type: "POST",
                    url: "LiveResult.aspx/LoadQueue",
                    data: '{param1:"' + temp + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var result = response.d;
                        if ($.trim(result).length == 0) {
                            return;
                        }

                        var objleft = jQuery.parseJSON(result);

                        if (objleft.Exist == '0') {
                            $('.table').hide();
                            $('.clock').show();
                            $('.message').hide();
                            return;
                        } else {
                            //if ($.trim(objleft.Symbol).length == 0) {
                            //    //Đang tường thuật
                            //    if (now.getHours() = 18 & now.getHours() <= 30)
                            //    $('.table').show();
                            //    $('.clock').hide();
                            //    $('.message').show();
                            //} else {
                                $('.table').hide();
                                $('.clock').show();
                                $('.message').hide();
                           // }
                        }

                        $('#lblCurrentTime').text(objleft.Lot_Time);

                        //Đặc biệt:
                        if ($.trim(objleft.Prize_0_1).length > 0) {
                            $('#lblResult_01').text(objleft.Prize_0_1);
                            $('#img01').hide();
                        } else {

                            $('#img01').show();
                            $('#lblResult_01').text("");
                        }
                        //Giải nhất:
                        if ($.trim(objleft.Prize_1_1).length > 0) {
                            $('#lblResult_11').text(objleft.Prize_1_1);
                            $('#img11').hide();
                        } else {
                            $('#img11').show();
                            $('#lblResult_11').text("");

                        }
                        //Giải nhì:
                        if ($.trim(objleft.Prize_2_1).length > 0) {
                            $('#lblResult_21').text(objleft.Prize_2_1);
                            $('#img21').hide();
                        } else {

                            $('#img21').show();
                            $('#lblResult_21').text("");
                        }
                        if ($.trim(objleft.Prize_2_2).length > 0) {
                            $('#lblResult_22').text(objleft.Prize_2_2);
                            $('#img22').hide();
                        } else {

                            $('#img22').show();
                            $('#lblResult_22').text("");

                        }
                        //Giải ba:
                        if ($.trim(objleft.Prize_3_1).length > 0) {
                            $('#lblResult_31').text(objleft.Prize_3_1);
                            $('#img31').hide();
                        } else {

                            $('#img31').show();
                            $('#lblResult_31').text("");
                        }
                        if ($.trim(objleft.Prize_3_2).length > 0) {
                            $('#lblResult_32').text(objleft.Prize_3_2);
                            $('#img32').hide();
                        } else {

                            $('#img32').show();
                            $('#lblResult_32').text("");

                        }
                        if ($.trim(objleft.Prize_3_3).length > 0) {
                            $('#lblResult_33').text(objleft.Prize_3_3);
                            $('#img33').hide();
                        } else {

                            $('#img33').show();
                            $('#lblResult_33').text("");

                        }
                        if ($.trim(objleft.Prize_3_4).length > 0) {
                            $('#lblResult_34').text(objleft.Prize_3_4);
                            $('#img34').hide();
                        } else {
                            $('#img34').show();
                            $('#lblResult_34').text("");
                        }
                        if ($.trim(objleft.Prize_3_5).length > 0) {
                            $('#lblResult_35').text(objleft.Prize_3_5);
                            $('#img35').hide();
                        } else {
                            $('#img35').show();
                            $('#lblResult_35').text("");
                        }
                        if ($.trim(objleft.Prize_3_6).length > 0) {
                            $('#lblResult_36').text(objleft.Prize_3_6);
                            $('#img36').hide();
                        } else {
                            $('#img36').show();
                            $('#lblResult_36').text("");
                        }
                        //Giải tư:
                        if ($.trim(objleft.Prize_4_1).length > 0) {
                            $('#lblResult_41').text(objleft.Prize_4_1);
                            $('#img41').hide();
                        } else {
                            $('#img41').show();
                            $('#lblResult_41').text("");
                        }
                        if ($.trim(objleft.Prize_4_2).length > 0) {
                            $('#lblResult_42').text(objleft.Prize_4_2);
                            $('#img42').hide();
                        } else {
                            $('#img42').show();
                            $('#lblResult_42').text("");
                        }
                        if ($.trim(objleft.Prize_4_3).length > 0) {
                            $('#lblResult_43').text(objleft.Prize_4_3);
                            $('#img43').hide();
                        } else {
                            $('#img43').show();
                            $('#lblResult_43').text("");
                        }
                        if ($.trim(objleft.Prize_4_4).length > 0) {
                            $('#lblResult_44').text(objleft.Prize_4_4);
                            $('#img44').hide();
                        } else {
                            $('#img44').show();
                            $('#lblResult_44').text("");
                        }
                        //Giải năm:
                        if ($.trim(objleft.Prize_5_1).length > 0) {
                            $('#lblResult_51').text(objleft.Prize_5_1);
                            $('#img51').hide();
                        } else {

                            $('#img51').show();
                            $('#lblResult_51').text("");
                        }
                        if ($.trim(objleft.Prize_5_2).length > 0) {
                            $('#lblResult_52').text(objleft.Prize_5_2);
                            $('#img52').hide();
                        } else {

                            $('#img52').show();
                            $('#lblResult_52').text("");

                        }
                        if ($.trim(objleft.Prize_5_3).length > 0) {
                            $('#lblResult_53').text(objleft.Prize_5_3);
                            $('#img53').hide();
                        } else {

                            $('#img53').show();
                            $('#lblResult_53').text("");

                        }
                        if ($.trim(objleft.Prize_5_4).length > 0) {
                            $('#lblResult_54').text(objleft.Prize_5_4);
                            $('#img54').hide();
                        } else {
                            $('#img54').show();
                            $('#lblResult_54').text("");
                        }
                        if ($.trim(objleft.Prize_5_5).length > 0) {
                            $('#lblResult_55').text(objleft.Prize_5_5);
                            $('#img55').hide();
                        } else {
                            $('#img55').show();
                            $('#lblResult_55').text("");
                        }
                        if ($.trim(objleft.Prize_5_6).length > 0) {
                            $('#lblResult_56').text(objleft.Prize_5_6);
                            $('#img56').hide();
                        } else {
                            $('#img56').show();
                            $('#lblResult_56').text("");
                        }
                        //Giải sáu:
                        if ($.trim(objleft.Prize_6_1).length > 0) {
                            $('#lblResult_61').text(objleft.Prize_6_1);
                            $('#img61').hide();
                        } else {

                            $('#img61').show();
                            $('#lblResult_61').text("");
                        }
                        if ($.trim(objleft.Prize_6_2).length > 0) {
                            $('#lblResult_62').text(objleft.Prize_6_2);
                            $('#img62').hide();
                        } else {

                            $('#img62').show();
                            $('#lblResult_62').text("");
                        }
                        if ($.trim(objleft.Prize_6_3).length > 0) {
                            $('#lblResult_63').text(objleft.Prize_6_3);
                            $('#img63').hide();
                        } else {

                            $('#img63').show();
                            $('#lblResult_63').text("");
                        }
                        //Giải bẩy:
                        if ($.trim(objleft.Prize_7_1).length > 0) {
                            $('#lblResult_71').text(objleft.Prize_7_1);
                            $('#img71').hide();
                        } else {
                            $('#img71').show();
                            $('#lblResult_71').text("");
                        }
                        if ($.trim(objleft.Prize_7_2).length > 0) {
                            $('#lblResult_72').text(objleft.Prize_7_2);
                            $('#img72').hide();
                        } else {
                            $('#img72').show();
                            $('#lblResult_72').text("");
                        }
                        if ($.trim(objleft.Prize_7_3).length > 0) {
                            $('#lblResult_73').text(objleft.Prize_7_3);
                            $('#img73').hide();
                        } else {
                            $('#img73').show();
                            $('#lblResult_73').text("");
                        }
                        if ($.trim(objleft.Prize_7_4).length > 0) {
                            $('#lblResult_74').text(objleft.Prize_7_4);
                            $('#img74').hide();
                        } else {
                            $('#img74').show();
                            $('#lblResult_74').text("");
                        }

                        if ($.trim(objleft.Symbol).length > 0) {
                            $('#lblSymbol').text(objleft.Symbol);
                            $('#imgsymbol').hide();
                        } else {
                            $('#imgsymbol').show();
                            $('#lblResult_74').text("");
                        }


                    },
                    failure: function (response) {
                        alert('Error !');
                    }
                });
            }, 5000)
        })



        //Load ajax control
        function AjaxLoadControl1(url) {
            GetHtml(url, '#ajaxcontrol1')
        }

        function GetHtml(url, div) {
            url = url + '&rd=' + Math.random();
            var heightdiv = $(div).height();
            $(div).html("loading...")
            $.get(encodeURI(url),

 function (data) {
     //get response text only
     var s = data.indexOf('<responsetext>')
     var t = data.indexOf('</responsetext>')
     var response = data.substring(s + 16, t)
     $(div).html(response)
 })
        }
    </script>
    <!--CountDown Clock -->
    <script type="text/javascript">

        var offset = 0;
        var now = new Date();
        var date1815 = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 18, 15, 0, 0);
        var date1830 = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 18, 30, 0, 0);
        var date2400 = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 23, 59, 59, 0);
        var date0000 = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 0, 0, 0, 0);
        var T1 = date1815.getTime() - now.getTime();
        var T2 = date1830.getTime() - now.getTime();
        if (T1 > 0)//Nếu thời gian hiện tại chưa đến thời điểm bắt đầu quay kết quả
        {
            offset = T1;
        } else if (T2 > 0)//  Nếu đang trong khoảng thời gian quay kết quả
        {
            offset = 0;
        } else// Nếu đã quay xong
        {

            var T3 = date2400.getTime() - now.getTime();
            var T4 = date1815.getTime() - date0000.getTime();
            offset = (T3 + T4);
        }



        var clock;
        $(document).ready(function () {
            
            $('.table').hide();
            $('.clock').hide();
            $('.message').hide();
           
            clock = $('.clock').FlipClock({
                clockFace: 'DailyCounter',
                autoStart: false,
                callbacks: {
                    stop: function () {
                        $('.message').html('CHÚC BẠN MAY MẮN !')
                        $('.clock').hide();
                    }
                }
            });

            clock.setTime(offset / 1000);
            clock.setCountdown(true);
            clock.start();

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="table_time">
            <div class="row_time">

                <div class="cell_time">
                    <asp:Label ID="lblCurrentTime" CssClass="label" runat="server" Font-Bold="True" Font-Size="12"> TƯỜNG THUẬT TRỰC TIẾP KẾT QUẢ XỔ SỐ</asp:Label>
                    <div class="clock" style="margin: 2em auto auto auto">
                    </div>
                    <div class="message" style="font-family: Arial; font-size: 20px; font-weight: bold; color: #FF0000">CẢM ƠN BẠN, CHÚC BẠN MAY MẮN ! </div>
                </div>

            </div>

        </div>
        <div class="table">
            <div class="row">
                <div class="cell_prize">
                    <asp:Label ID="Label10" runat="server" CssClass="label" Font-Size="14pt" ForeColor="Red">Đặc biệt:</asp:Label>
                </div>

                <div class="cell">
                    <asp:Label ID="lblResult_01" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt" ForeColor="Red"></asp:Label>
                    <img id="img01" src="../../Images/loading.gif" />
                </div>

            </div>
            <div class="row">
                <div class="cell_prize">
                    <asp:Label ID="Label1" runat="server" CssClass="label" Font-Size="14pt">Giải nhất:</asp:Label>
                </div>
                <div class="cell">
                    <asp:Label ID="lblResult_11" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label>
                    <img id="img11" src="../../Images/loading.gif" />
                </div>

            </div>
            <div class="row">
                <div class="cell_prize">
                    <asp:Label ID="Label2" runat="server" CssClass="label" Font-Size="14pt">Giải nhì:</asp:Label>
                </div>
                <div class="cell">
                    <div class="table_2">
                        <div class="row_2">
                            <div class="cell_21">
                                <asp:Label ID="lblResult_21" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img21" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_22">
                                <asp:Label ID="lblResult_22" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img22" src="../../Images/loading.gif" />
                            </div>
                        </div>
                    </div>

                </div>

            </div>
            <div class="row">
                <div class="cell_prize">
                    <asp:Label ID="Label3" runat="server" CssClass="label" Font-Size="14pt">Giải ba:</asp:Label>
                </div>
                <div class="cell">
                    <div class="table_3">
                        <div class="row_3">
                            <div class="cell_31">
                                <asp:Label ID="lblResult_31" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img31" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_32">
                                <asp:Label ID="lblResult_32" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img32" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_33">
                                <asp:Label ID="lblResult_33" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img33" src="../../Images/loading.gif" />
                            </div>
                        </div>
                        <div class="row_3">
                            <div class="cell_34">
                                <asp:Label ID="lblResult_34" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img34" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_35">
                                <asp:Label ID="lblResult_35" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img35" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_36">
                                <asp:Label ID="lblResult_36" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img36" src="../../Images/loading.gif" />
                            </div>
                        </div>
                    </div>

                </div>

            </div>
            <div class="row">
                <div class="cell_prize">
                    <asp:Label ID="Label4" runat="server" CssClass="label" Font-Size="14pt">Giải tư:</asp:Label>
                </div>
                <div class="cell">
                    <div class="table_4">
                        <div class="row_4">
                            <div class="cell_41">
                                <asp:Label ID="lblResult_41" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img41" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_41">
                                <asp:Label ID="lblResult_42" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img42" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_41">
                                <asp:Label ID="lblResult_43" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img43" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_42">
                                <asp:Label ID="lblResult_44" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img44" src="../../Images/loading.gif" />
                            </div>
                        </div>
                    </div>

                </div>

            </div>
            <div class="row">
                <div class="cell_prize">
                    <asp:Label ID="Label5" runat="server" CssClass="label" Font-Size="14pt">Giải năm:</asp:Label>
                </div>
                <div class="cell">
                    <div class="table_3">
                        <div class="row_3">
                            <div class="cell_31">
                                <asp:Label ID="lblResult_51" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img51" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_32">
                                <asp:Label ID="lblResult_52" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img52" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_33">
                                <asp:Label ID="lblResult_53" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img53" src="../../Images/loading.gif" />
                            </div>
                        </div>
                        <div class="row_3">
                            <div class="cell_34">
                                <asp:Label ID="lblResult_54" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img54" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_35">
                                <asp:Label ID="lblResult_55" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img55" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_36">
                                <asp:Label ID="lblResult_56" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img56" src="../../Images/loading.gif" />
                            </div>
                        </div>
                    </div>

                </div>

            </div>
            <div class="row">
                <div class="cell_prize">
                    <asp:Label ID="Label6" runat="server" CssClass="label" Font-Size="14pt">Giải sáu:</asp:Label>
                </div>
                <div class="cell">
                    <div class="table_3">
                        <div class="row_3">
                            <div class="cell_34">
                                <asp:Label ID="lblResult_61" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img61" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_35">
                                <asp:Label ID="lblResult_62" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img62" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_36">
                                <asp:Label ID="lblResult_63" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img63" src="../../Images/loading.gif" />
                            </div>
                        </div>
                    </div>

                </div>

            </div>
            <div class="row">
                <div class="cell_prize">
                    <asp:Label ID="Label7" runat="server" CssClass="label" Font-Size="14pt">Giải bảy:</asp:Label>
                </div>
                <div class="cell">
                    <div class="table_4">
                        <div class="row_4">
                            <div class="cell_41">
                                <asp:Label ID="lblResult_71" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img71" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_41">
                                <asp:Label ID="lblResult_72" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img72" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_41">
                                <asp:Label ID="lblResult_73" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img73" src="../../Images/loading.gif" />
                            </div>
                            <div class="cell_42">
                                <asp:Label ID="lblResult_74" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label><img id="img74" src="../../Images/loading.gif" />
                            </div>
                        </div>
                    </div>

                </div>

            </div>
            <div class="row">
                <div class="cell_prize">
                    <asp:Label ID="Label8" runat="server" CssClass="label" Font-Underline="False" Font-Italic="False" Font-Size="11pt" ForeColor="Blue">Ký hiệu vé:</asp:Label>
                </div>
                <div class="cell" style="text-align: left; padding-left: 15px;">
                    <asp:Label ID="lblSymbol" runat="server" CssClass="label" Font-Bold="True" Font-Size="16pt"></asp:Label>
                    <img id="imgsymbol" src="../../Images/loading.gif" />
                </div>

            </div>
        </div>
    </form>
</body>
</html>

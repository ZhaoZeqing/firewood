<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkNum.aspx.cs" Inherits="firewood.checknum" %>

<%@ Register TagPrefix="fw" TagName="Top" Src="control/top.ascx" %>
<%@ Register TagPrefix="fw" TagName="Head" Src="control/head.ascx" %>
<%@ Register TagPrefix="fw" TagName="Foot" Src="control/foot.ascx" %>

<!DOCTYPE html>
<html lang="zh-CN">

<head>
    <meta charset="UTF-8">
    <meta name="renderer" content="webkit">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="js/html5shiv.min.js"></script>
      <script src="js/respond.min.js"></script>
    <![endif]-->
    <title>学号验证 - 柴火 | 学生活动发布平台</title>
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/common.css">
    <link rel="stylesheet" media="only screen and (min-device-width: 992px)" href="css/index.css">
    <link rel="stylesheet" media="only screen and (max-width: 992px)" href="css/mobile-index.css">
    <link rel="stylesheet" href="css/reg.css">
</head>
<body>
    <fw:Top ID="top" runat="server"></fw:Top>
    <div class="container">
        <fw:Head ID="head" runat="server"></fw:Head>
        <!--Main-->
        <div class="row">
            <div id="reg-main">
                <h3>学号验证</h3>
                <div class="center">
                    <form class="form-horizontal" runat="server">
                        <div class="form-group">
                            <label class="col-sm-4 control-label">学号</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" id="worknum" runat="server" maxlength="20" required />
                                <p class="help-block"></p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label">上网密码</label>
                            <div class="col-sm-8">
                                <input type="password" class="form-control" id="pwd" runat="server" name="pwd" required />
                                <p class="help-block"></p>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <button type="submit" class="btn btn-warning btn-lg btn-block" onserverclick="check" runat="server">确定</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <fw:Foot ID="foot" runat="server"></fw:Foot>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jqBootstrapValidation.js"></script>
    <script src="js/fw.js"></script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="firewood.login" %>

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
    <title>用户登录 - 柴火 | 学生活动发布平台</title>
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
                <h3>用户登录</h3>
                <div class="center">
                    <form class="form-horizontal" runat="server">
                        <div class="form-group">
                            <label class="col-md-4 control-label">昵称/邮箱</label>
                            <div class="col-md-8">
                                <input type="text" class="form-control" id="uInfo" runat="server" maxlength="50" required />
                                <p class="help-block"></p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-4 control-label">密码</label>
                            <div class="col-md-8">
                                <input type="password" class="form-control" name="pwd" id="uPwd" runat="server" maxlength="50" required />
                                <p class="help-block"></p>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4 col-sm-6 col-xs-6 col-md-offset-4">
                                <div class="checkbox" style="margin-left:20px">
                                    <input type="checkbox" id="savePwd" runat="server" />
                                    记住密码
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-6 col-xs-6 control-label">
                                <a href="checkNum.aspx?id=1" title="忘记密码">忘记密码</a>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12">
                                <button type="submit" class="btn btn-warning btn-lg btn-block" onserverclick="Log" runat="server">登录</button>
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


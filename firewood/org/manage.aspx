<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="firewood.org.manage" %>

<%@ Register TagPrefix="fw" TagName="Top" Src="../control/top.ascx" %>
<%@ Register TagPrefix="fw" TagName="Foot" Src="../control/foot.ascx" %>

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
    <title>后台管理 柴火 | 学生活动发布平台</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css">
    <link rel="stylesheet" href="../css/common.css">
    <link rel="stylesheet" media="only screen and (min-device-width: 992px)" href="../css/index.css">
    <link rel="stylesheet" media="only screen and (max-width: 992px)" href="../css/mobile-index.css">
    <link rel="stylesheet" href="../css/reg.css">
</head>

<body>
    <fw:Top ID="top" runat="server"></fw:Top>
    <div class="container">
        <div class="row hidden-xs hidden-sm" id="index-head">
            <div class="col-md-9">
                <span id="index-logo">柴火<small>后台管理</small></span>
            </div>
        </div>
        <ul class="nav nav-tabs">
            <li role="presentation" class="active">
                <a href="#reg-org" role="tab" data-toggle="tab">注册社团/组织</a>
            </li>
            <li role="presentation">
                <a href="#find-org" role="tab" data-toggle="tab">查询社团/组织</a>
            </li>
            <li role="presentation">
                <a href="#del-org" role="tab" data-toggle="tab">注销社团/组织</a>
            </li>
        </ul>
        <div class="tab-content">
            <!--===Reg-Org===-->
            <div class="tab-pane active" id="reg-org">
                <div class="center">
                    <form class="form-horizontal" runat="server">
                        <div class="form-group">
                            <label class="col-sm-4 control-label">社团名称</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" id="orgName" runat="server" maxlength="50" required />
                                <p class="help-block" id="orgNameP"></p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label">密码</label>
                            <div class="col-sm-8">
                                <input type="password" class="form-control" id="orgPwd" runat="server" maxlength="50" required />
                                <p class="help-block"></p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label">确认密码</label>
                            <div class="col-sm-8">
                                <input type="password" class="form-control" id="orgPwd1" runat="server" maxlength="50" required />
                                <p class="help-block" id="orgPwdP"></p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label">负责人姓名</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" id="orgPrincipal" runat="server" maxlength="50" required />
                                <p class="help-block" id="orgPrincipalP"></p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label">负责人电话</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" id="orgTel" runat="server" maxlength="50" required />
                                <p class="help-block" id="orgTelP"></p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label">所属单位</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" id="orgDepartment" runat="server" maxlength="50" required />
                                <p class="help-block" id="orgDepartmentP"></p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label">上传头像</label>
                            <div class="col-sm-8">
                                <input type="file" id="orgPic">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label">简介</label>
                            <div class="col-sm-8">
                                <textarea rows="8" class="form-control" id="orgIntroduction" runat="server" maxlength="500" required></textarea>
                                <p class="help-block" id="orgIntroductionP"></p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label">联系方式</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" id="orgContact" runat="server" maxlength="50" required />
                                <p class="help-block" id="orgContactP"></p>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <button type="submit" class="btn btn-warning btn-lg btn-block" onserverclick="orgRegister" runat="server">注册</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
            <!--===Find-Org-->
            <div class="tab-pane" id="find-org">
                <div class="center">
                    <form >
                        <div class="input-group input-group-lg" id="index-search">
                            <input type="text" class="form-control" placeholder="请输入社团/组织的名称..." aria-describedby="basic-addon2">
                            <span class="input-group-btn">
                                <button class="btn btn-default" type="button" id="index-search-btn">
                                    <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                                </button>
                            </span>
                        </div>
                    </form>
                </div>
            </div>
            <!--===Del-Org-->
            <div class="tab-pane" id="del-org">
                <div class="center">
                    <form class="form-horizontal">
                        <div class="form-group">
                            <label class="col-sm-4 control-label">社团/组织名称</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" id="orgNameDel" runat="server" maxlength="50" required />
                                <p class="help-block" id="orgNameDelP"></p>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <button type="submit" class="btn btn-warning btn-lg btn-block" onserverclick="orgDel" runat="server">注销</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <fw:Foot ID="foot" runat="server"></fw:Foot>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/fw.js"></script>
</body>
</html>

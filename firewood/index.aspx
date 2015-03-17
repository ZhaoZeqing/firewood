<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="firewood.index" %>
<%@ Register TagPrefix="fw" TagName="Top" Src="control/top.ascx" %>
<%@ Register TagPrefix="fw" TagName="Head" Src="control/head.ascx" %>
<%@ Register TagPrefix="fw" TagName="IndexRight" Src="control/indexRight.ascx" %>
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
    <title>柴火 | 学生活动发布平台</title>
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/common.css">
    <link rel="stylesheet" media="only screen and (min-device-width: 992px)" href="css/index.css">
    <link rel="stylesheet" media="only screen and (max-width: 992px)" href="css/mobile-index.css">
</head>
<body>
    <fw:Top ID="top" runat="server"></fw:Top>
    <div class="container">
        <fw:Head ID="head" runat="server"></fw:Head>
        <!--Main-->
        <div class="row">
            <div class="col-md-8 lasted-events">
                <div class="con-title" id="lasted-events-title"></div>
                <ul id="index-condition" class="hidden-xs hidden-sm">
                    <ul>
                        <li class="conbold">条件筛选 &gt; </li>
                        <li class="conbold" id="con1">按地点</li>
                        <li><a href="" title="800人厅">800人厅</a>
                        </li>
                        <li><a href="" title="300人厅">300人厅</a>
                        </li>
                        <li><a href="" title="视频会议厅">视频会议厅</a>
                        </li>
                        <li><a href="" title="国际报告厅">国际报告厅</a>
                        </li>
                        <li><a href="" title="音乐厅">音乐厅</a>
                        </li>
                        <li><a href="" title="教学楼">教学楼</a>
                        </li>
                        <li><a href="" title="户外">户外</a>
                        </li>
                        <li><a href="" title="其他">其他</a>
                        </li>
                    </ul>
                    <ul>
                        <li class="conbold" id="con2">按其他</li>
                        <li><a href="" title="加分">加分</a>
                        </li>
                        <li><a href="" title="第二课堂认定">第二课堂认定</a>
                        </li>
                        <li><a href="" title="奖金">奖金</a>
                        </li>
                    </ul>
                </ul>
                <div class="row">
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-6 col-sm-3">
                                <div class="img-events"></div>
                            </div>
                            <div class="col-md-6 col-sm-9">
                                <h3>HEADING</h3>
                                <p>Phasellus facilisis, nunc in lacinia auctor, eros lacus aliquet velit, quis lobortis risus nunc nec nisi. Maecenas et amet est. Uthasellus aliquet</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-6 col-sm-3">
                                <div class="img-events"></div>
                            </div>
                            <div class="col-md-6 col-sm-9">
                                <h3>HEADING</h3>
                                <p>Phasellus facilisis, nunc in lacinia auctor, eros lacus aliquet velit, quis lobortis risus nunc nec nisi. Maecenas et amet est. Uthasellus aliquet</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-6 col-sm-3">
                                <div class="img-events"></div>
                            </div>
                            <div class="col-md-6 col-sm-9">
                                <h3>HEADING</h3>
                                <p>Phasellus facilisis, nunc in lacinia auctor, eros lacus aliquet velit, quis lobortis risus nunc nec nisi. Maecenas et amet est. Uthasellus aliquet</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-6 col-sm-3">
                                <div class="img-events"></div>
                            </div>
                            <div class="col-md-6 col-sm-9">
                                <h3>HEADING</h3>
                                <p>Phasellus facilisis, nunc in lacinia auctor, eros lacus aliquet velit, quis lobortis risus nunc nec nisi. Maecenas et amet est. Uthasellus aliquet</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-6 col-sm-3">
                                <div class="img-events"></div>
                            </div>
                            <div class="col-md-6 col-sm-9">
                                <h3>HEADING</h3>
                                <p>Phasellus facilisis, nunc in lacinia auctor, eros lacus aliquet velit, quis lobortis risus nunc nec nisi. Maecenas et amet est. Uthasellus aliquet</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-6 col-sm-3">
                                <div class="img-events"></div>
                            </div>
                            <div class="col-md-6 col-sm-9">
                                <h3>HEADING</h3>
                                <p>Phasellus facilisis, nunc in lacinia auctor, eros lacus aliquet velit, quis lobortis risus nunc nec nisi. Maecenas et amet est. Uthasellus aliquet</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-6 col-sm-3">
                                <div class="img-events"></div>
                            </div>
                            <div class="col-md-6 col-sm-9">
                                <h3>HEADING</h3>
                                <p>Phasellus facilisis, nunc in lacinia auctor, eros lacus aliquet velit, quis lobortis risus nunc nec nisi. Maecenas et amet est. Uthasellus aliquet</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-6 col-sm-3">
                                <div class="img-events"></div>
                            </div>
                            <div class="col-md-6 col-sm-9">
                                <h3>HEADING</h3>
                                <p>Phasellus facilisis, nunc in lacinia auctor, eros lacus aliquet velit, quis lobortis risus nunc nec nisi. Maecenas et amet est. Uthasellus aliquet</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <fw:indexright id="indexRight" runat="server"></fw:indexright>
        </div>
    </div>
    <fw:foot id="foot" runat="server"></fw:foot>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/fw.js"></script>
</body>
</html>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="head.ascx.cs" Inherits="firewood.control.head" %>
<!--Head-->
<div class="row hidden-xs hidden-sm" id="index-head">
    <div class="col-md-9">
        <img src="../img/logo.png" />
    </div>
    <div class="col-md-3">
        <form action="">
            <div class="input-group input-group-lg" id="index-search">
                <input type="text" class="form-control" placeholder="输入关键词开始搜索..." aria-describedby="basic-addon2">
                <span class="input-group-btn">
                    <button class="btn btn-default" type="button" id="index-search-btn">
                        <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                    </button>
                </span>
            </div>
        </form>
    </div>
</div>
<!--Mobile_Head-->
<div class="row hidden-md hidden-lg">
    <div class="col-sm-12">
        <img src="img/mobile-head.png" alt="">
    </div>
</div>
<!--Nav-->
<div class="row hidden-xs hidden-sm">
    <div class="col-md-12" id="index-nav">
        <div class="row">
            <div class="col-md-9">
                <ul class="nav-list">
                    <li class="dropdown" id="nav1">
                        <a href="" title="比赛"></a>
                        <ul class="dropdown-menu" role="menu" aria-labelledby="nav1">
                            <li role="presentation">
                                <a role="menuitem" tabindex="-1" href="#">文娱</a>
                            </li>
                            <li role="presentation">
                                <a role="menuitem" tabindex="-1" href="#">财经</a>
                            </li>
                            <li role="presentation">
                                <a role="menuitem" tabindex="-1" href="#">体育</a>
                            </li>
                            <li role="presentation">
                                <a role="menuitem" tabindex="-1" href="#">创意</a>
                            </li>
                            <li role="presentation">
                                <a role="menuitem" tabindex="-1" href="#">其他</a>
                            </li>
                        </ul>
                    </li>
                    <li class="dropdown" id="nav2">
                        <a href="" title="讲座"></a>
                        <ul class="dropdown-menu" role="menu" aria-labelledby="nav2">
                            <li role="presentation">
                                <a role="menuitem" tabindex="-1" href="#">宣讲会</a>
                            </li>
                            <li role="presentation">
                                <a role="menuitem" tabindex="-1" href="#">财经</a>
                            </li>
                            <li role="presentation">
                                <a role="menuitem" tabindex="-1" href="#">文化素质</a>
                            </li>
                            <li role="presentation">
                                <a role="menuitem" tabindex="-1" href="#">分享</a>
                            </li>
                            <li role="presentation">
                                <a role="menuitem" tabindex="-1" href="#">其他</a>
                            </li>
                        </ul>
                    </li>
                    <li id="nav3">
                        <a href="" title="演出"></a>
                    </li>
                    <li id="nav4">
                        <a href="" title="聚会"></a>
                    </li>
                    <li id="nav5">
                        <a href="" title="公益"></a>
                    </li>
                    <li id="nav6">
                        <a href="" title="其他"></a>
                    </li>
                </ul>
            </div>
            <ul class="col-md-3" id="log-reg">
                <li class="col-md-4">
                    <a href="login.aspx" title="登录">
                        <span class="glyphicon glyphicon-user menu-on-icon"></span>
                        <span class="glyphicon-class">登录</span>
                    </a>
                </li>
                <li class="col-md-4">
                    <a href="uReg.aspx" title="注册">
                        <span class="glyphicon glyphicon-plus-sign menu-on-icon"></span>
                        <span class="glyphicon-class">注册</span>
                    </a>
                </li>
            </ul>
            <div class="col-md-3" id="nav-user">
                <div id="user-img"></div>
                <div id="user-name">
                    <span>你好：</span>
                    <span id="nav-uname"></span>
                </div>
                <div id="user-btn">
                    <span class="glyphicon glyphicon-align-justify menu-icon"></span>
                </div>
            </div>
            <ul id="menu-on">
                <li class="col-md-4">
                    <a href="#">
                        <span class="glyphicon glyphicon-cog menu-on-icon"></span>
                        <span class="glyphicon-class">个人中心</span>
                    </a>
                </li>
                <li class="col-md-4">
                    <a href="exit.aspx?id=0" title="身份切换">
                        <span class="glyphicon glyphicon-user menu-on-icon"></span>
                        <span class="glyphicon-class">身份切换</span>
                    </a>
                </li>
                <li class="col-md-4">
                    <a href="exit.aspx?id=1" title="退出登录">
                        <span class="glyphicon glyphicon-log-out menu-on-icon"></span>
                        <span class="glyphicon-class">退出登录</span>
                    </a>
                </li>
            </ul>
        </div>
    </div>
</div>
<!--Mobile_Nav-->
<div class="row hidden-md hidden-lg">
    <div class="col-sm-12" id="index-mobile-nav">
        <ul>
            <li><a href="" title="比赛">比赛</a>
            </li>
            <li><a href="" title="讲座">讲座</a>
            </li>
            <li><a href="" title="演出">演出</a>
            </li>
            <li><a href="" title="聚会">聚会</a>
            </li>
            <li><a href="" title="公益">公益</a>
            </li>
            <li><a href="" title="其他">其他</a>
            </li>
        </ul>
    </div>
</div>

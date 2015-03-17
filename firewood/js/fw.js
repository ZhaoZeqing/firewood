$(function () {
    $('#user-btn,#menu-on').mouseover(function(event) {
        $('#menu-on').show();
        $('#user-btn').css({ transform: 'translate(-5px, 0)'});
    }).mouseout(function(event) {
        $('#menu-on').hide();
        $('#user-btn').css({transform: 'translate(0, 0)'});
    });

    var cookieUserName = getCookie("UserName");
    if (cookieUserName.length > 0)
    {
        $("#log-reg").hide();
        $("#nav-user").show();
        $("#nav-uname").text(cookieUserName);
    }
    else {
        $("#log-reg").show();
    }

    var uname = $('#nav-uname');
    if (textSize("14px", uname.text()).width > 100) {
        var i = uname.text().length;
        while (textSize("14px", uname.text() + "...").width >= 100) {
            uname.text(uname.text().substr(0, i));
            i--;
        }
        uname.text(uname.text() + "...");
    }
});

function textSize(fontSize, text) {
    var span = document.createElement("span");
    var result = {};
    result.width = span.offsetWidth;
    result.height = span.offsetWidth;
    span.style.visibility = "hidden";
    document.body.appendChild(span);
    if (typeof span.textContent != "undefined")
        span.textContent = text;
    else span.innerText = text;
    result.width = span.offsetWidth - result.width;
    result.height = span.offsetHeight - result.height;
    span.parentNode.removeChild(span);
    return result;
}
function getCookie(c_name) {
    if (document.cookie.length > 0) {
        c_start = document.cookie.indexOf(c_name + "=")
        if (c_start != -1) {
            c_start = c_start + c_name.length + 1
            c_end = document.cookie.indexOf(";", c_start)
            if (c_end == -1) c_end = document.cookie.length
            return unescape(document.cookie.substring(c_start, c_end))
        }
    }
    return "";
}
//==========================================================User Register
function uNamePost() {
    var uName = $('#uName').val();
    var a = "{'uName':'" + uName + "'}";
    $.ajax({
        type: "Post",
        url: "uReg.aspx/uNamePost",
        data: a,
        contentType: "application/json; charset=gb2312",
        dataType: "json",
        beforesend: function () { },
        success: function (data) {
            var result = data.d;
            sthExit(result);
        },
        error: function (err) {
            alert(err);
        }
    });
}
function uMailPost() {
    var uMail = $('#uMail').val();
    var a = "{'uMail':'" + uMail + "'}";
    $.ajax({
        type: "Post",
        url: "uReg.aspx/uMailPost",
        data: a,
        contentType: "application/json; charset=gb2312",
        dataType: "json",
        beforesend: function () { },
        success: function (data) {
            var result = data.d;
            sthExit(result);
        },
        error: function (err) {
            alert(err);
        }
    });
}

function uCheckPost() {
    var uCheck = $('#uCheck').val();
    var a = "{'uCheck':'" + uCheck + "'}";
    $.ajax({
        type: "Post",
        url: "uReg.aspx/uCheckPost",
        data: a,
        contentType: "application/json; charset=gb2312",
        dataType: "json",
        beforesend: function () { },
        success: function (data) {
            var result = data.d;
            sthExit(result);
        },
        error: function (err) {
            alert(err);
        }
    });
}

function sthExit(n){
    if (n == "0") {
        $('#uNameP').text("");
    }
    else if(n == "1"){
        $('#uNameP').text("昵称存在！");
        $('#uName').bind('input propertychange', function () {
            uName = $('#uName').val();
        });
    }
    else if (n == "2") {
        $('#uMailP').text("");
    }
    else if (n == "3") {
        $('#uMailP').text("邮箱存在！");
        $('#uMail').bind('input propertychange', function () {
            uMail = $('#uName').val();
        });
    }
    else if (n == "4") {
        $("#uCheckP").text("验证码错误！");
        $('#uCheck').bind('input propertychange', function () {
            uCheck = $('#uCheckP').val();
        });
    }
    else if (n == "5") {
        $("#uCheckP").text("");
    }
    else if (n == "6") {
        $("#uCheckP").text("验证码生成错误！");
    }
}
$(function () {
    var uName, uMail, uCheck, pwd, pwd1;

    $('#uName').bind('input propertychange', function () {
        uName = $('#uName').val();
        uNamePost();
    });
    $('#uMail').bind('input propertychange', function () {
        uMail = $('#uMail').val();
        uMailPost();
    });
    $('#uCheck').bind('input propertychange', function () {
        uCheck = $('#uCheck').val();
        uCheckPost();
    });
    $('#pwd1').bind('input propertychange', function () {
        pwd = $('#pwd').val();
        pwd1 = $('#pwd1').val();
        if (pwd != pwd1) {
            $("#uPwdP").text("密码不一致！");
        }
        else {
            $("#uPwdP").text("");
        }
    });
});
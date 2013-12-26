/// <reference path="jquery-1.4.2.min.js" />

var selectNode = null;//左邊菜單中當前選擇的節點

$(document).ready(function() {
    InitLeftMenu();

    $.post('ashx/mainMenu.ashx', function(Return) {
        if (Return == "logout" || Return == "error") {
            parent.location.href = "../login.html";
        }
        else if (Return.indexOf('當前用戶') != -1) {
            if ($('#LoginUser')[0] != null) {
                $('#LoginUser')[0].innerHTML = Return;
            }
        }
    });
});

//開發功能：初始化左側菜單
//開發者：楊碧清
function InitLeftMenu() {

    $("#leftMenu").empty();
    var menulist = "";

    $.post('ashx/leftMenu.ashx', function(data) {

        if (data == 'NoLogin') {
            parent.location.href = "../login.html";
            return;
        }
        else if (data == 'NoAccess') {
            return;
        }

        menulist = data;
        $("#leftMenu").append(menulist);

    })
}

function InitleftSubMenu(sid) {
    if (sid != "1") {
        whichEl = eval("submenu" + sid);
        imgmenu = eval("imgmenu" + sid);

        eval("submenu" + sid + ".style.display=\"none\";");
        imgmenu.background = "images/main_48.gif";

        //        if ($("#hid").val() != "") {
        //            eval("submenu" + $("#hid").val() + ".style.display=\"none\";");
        //            imgmenu.background = "images/main_47.gif";
        //        }


        //        if (whichEl.style.display == "none") {
        //            eval("submenu" + sid + ".style.display=\"\";");
        //            imgmenu.background = "images/main_47.gif";
        //        }
        //        else {
        //            
        //        }
    }
}

//開發功能：單擊左邊菜單項，右邊區域導航到指定頁面
//開發者：楊碧清
function SubMenuClick(url, CurrNode) {
    if (selectNode == CurrNode) {
        //return;
    }
    if (selectNode != null) {

        selectNode.style.backgroundColor = CurrNode.style.backgroundColor;
    }
    CurrNode.style.backgroundColor = "7bc4d3";
    selectNode = CurrNode;
    
    if (url != "") {
        parent.document.getElementById("rightFrame").setAttribute("src", url);
    }
}

//開發功能：退出系統
//開發者：楊碧清
function Qut() {
    $.post('ashx/LoginOut.ashx', function(Return) {
        if (Return == "success") {
            parent.location.href = "../login.html";
        }
        else {
            //$.messager.alert('系统提示', '登出錯誤!', 'warning');
            parent.location.href = "../login.html";
        }
    });
}
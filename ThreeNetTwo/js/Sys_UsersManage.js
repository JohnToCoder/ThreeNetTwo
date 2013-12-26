/*
功能描述：用戶管理功能實現
人員：劉洪彬 
時間：2011-03-16
*/
$(document).ready(function() {

     $('#GvUsers').find("tbody>tr>td>img").each(function() {
        var strImagePath = $(this).attr("src");
        if(strImagePath!="")
        {
          $(this).attr("src", "../Manage/PicFile/" + strImagePath);
          
        }
        else
        {
           $(this).attr("src", "../Manage/PicFile/0.jpg")
        
        }
        $(this).click(function() {
            $('#ShowImage').css("display", "block");
            if(strImagePath!="")
            {
              $('#imgBig').attr("src", "../Manage/PicFile/" + strImagePath);
            }
            else
            {
               $('#imgBig').attr("src", "../Manage/PicFile/0.jpg");
            
            }
            
        });
    });
    $('#imgBig').click(function() {
        $('#ShowImage').css("display", "none");
    });
    
    //Edit By Tanyi 圖片逐漸下載 2011.3.24
    $("img").lazyload({
        placeholder: "../images/grey.gif",
        effect: "fadeIn"
    }); 
    
    var lblOperator = $('#lblOperator');
    lblOperator.css("display", "none");

    //新增頁面及其確定與取消
    $('#btnIns').click(function() {
        openWinIns();
        var iFrameIns = $("#subFrameIns");
        iFrameIns[0].src = "../Manage/Sys_UsersManage_Edit.aspx?flag=ins";
    });
    $('#btnInsYes').click(function() {
        AjaxForUsersIns();
    });
    $('#btnCancel1').click(function() {
        $('#WinIns').window('close');
    });


    //查詢頁面及其確定與取消
    $('#btnSel').click(function() {
        openWinSel();
        var iFrameSel = $("#subFrameSel");
        iFrameSel[0].src = "../Manage/Sys_UsersManage_Edit.aspx?flag=sel";
    });
    $('#btnSelYes').click(function() {
        AjaxForMovieSearch('../Manage/Sys_UsersManage.aspx');
    });
    $('#btnCancel2').click(function() {
        $('#WinSel').window('close');
    });


    //修改頁面及其確定與取消
    $('#btnUpd').click(function() {
        var chk = $('tbody>tr>td').find(':checkbox')
        var chked = chk.filter(':checked');

        if (chked.length == 0) {
            $.messager.alert('系统提示', '請選擇要修改的資料！', 'warning');
        }
        else {
            openWinUpd();
            var chkKey = chked[0].parentNode.nextSibling.innerHTML;
            var iFrameUpd = $("#subFrameUpd");
           iFrameUpd[0].src = "../Manage/Sys_UsersManage_Edit.aspx?flag=upd&key=" + chkKey;
           }
    });
    $('#btnUpdYes').click(function() {
        AjaxForUserspd();
    });
    $('#btnCancel3').click(function() {
        $('#WinUpd').window('close');
    });

    //刪除頁面
    $('#btnDel').click(function() {
       DeleteClick(lblOperator);
    });
    var lblFlag = $('#lblFlag');
    lblFlag.css("display", "none");
    AlertFlag(lblFlag);
});


function openWinIns() {
    $('#WinIns').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 480,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 新增窗口'
    });
    $('#WinIns').css("display", "block");
    $('#WinIns').window('open');
}

function openWinSel() {
    $('#WinSel').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 400,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 查詢窗口'
    });
    $('#WinSel').css("display", "block");
    $('#WinSel').window('open');
}

function openWinUpd() {
    $('#WinUpd').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 480,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 修改窗口'
    });
    $('#WinUpd').css("display", "block");
    $('#WinUpd').window('open');
}


//新增用戶
function AjaxForUsersIns() {
    var iFrameContent =$("#subFrameIns").contents();
    var txtUserCode = iFrameContent.find('#txtUserCode').val();
    var txtUserName = iFrameContent.find('#txtUserName').val();
    var txtPassword = iFrameContent.find('#txtPassword').val();
    var txtcfPassword = iFrameContent.find('#txtcfPassword').val();
    var txtTEL= iFrameContent.find('#txtTEL').val();
    var txtEmail = iFrameContent.find('#txtEmail').val();
    var txtMobile=iFrameContent.find('#txtMobile').val();
    var ddlrole = iFrameContent.find('#ddlrole').val();
    var txtIP=iFrameContent.find('#txtIP').val();
    var file = iFrameContent.find("#fileUpload").val();
    var pos = file.lastIndexOf("/");
    if (pos == -1) {
        pos = file.lastIndexOf("\\");
    }
    var fuFileName = file.substr(pos + 1);
    
    if ($.trim(txtUserCode) == "") {
        $.messager.alert('系统提示', '用戶帳號不能爲空！', 'warning');
        return false;
    }
    if ($.trim(txtUserCode)!= "") {
        if (CheckStr(txtUserCode)) {
            $.messager.alert('系統提示', '用戶帳號中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
    if ($.trim(txtUserName)== "") {
        $.messager.alert('系统提示', '用戶名稱不能為空！', 'warning');
        return false;
    }   
    if ($.trim(txtUserName)!= "") {
        if (CheckStr(txtUserName)) {
            $.messager.alert('系統提示', '用戶名稱中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
   
    if ($.trim(txtPassword) == "") {
        $.messager.alert('系统提示', '密碼不能爲空！', 'warning');
        return false;
    }
    
    if($.trim(txtPassword) != ""&& $.trim(txtPassword).length<6)
    {
          $.messager.alert('系统提示', '密碼長度不能小于6位數！', 'warning');
          return false;
    
    }
    
    if ($.trim(txtPassword)!= "") {
        if (CheckStr(txtPassword)) {
            $.messager.alert('系統提示', '用戶密碼中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
       
    if ($.trim(txtcfPassword) == "") {
        $.messager.alert('系统提示', '確認密碼不能爲空！', 'warning');
        return false;
    }
    if($.trim(txtPassword)!=$.trim(txtcfPassword))
       {
          $.messager.alert('系统提示', '前后密碼不一致！', 'warning');
         
       }
       
//    if($.trim(file)=="")
//    {
//       {
//            $.messager.alert('系統提示', '請選擇上傳的圖片！', 'warning');
//            return false;
//       }
//    }
    if (CheckFile(fuFileName)) 
    {
        $.messager.alert('系統提示', '您只能上傳.jpg.gif.png.jpeg類型的圖片！', 'warning');
        return false;
    }
       
    if ($.trim(txtTEL) =="") {
        $.messager.alert('系统提示', '電話號碼不能爲空！', 'warning');
        return false;
    }
    
     if ($.trim(txtTEL) != "") {
        if (CheckStr(txtTEL)) {
            $.messager.alert('系統提示', '電話號碼中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
    
    if ($.trim(txtEmail) =="") {
        $.messager.alert('系统提示', '郵箱地址不能爲空！', 'warning');
        return false;
    }
     
     if ($.trim(txtEmail) != "") {
        if (CheckStrMail(txtEmail)) {
            $.messager.alert('系統提示', '郵箱地址中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
    
    
    if ($.trim(txtMobile) =="") {
        $.messager.alert('系统提示', '手機號碼不能爲空！', 'warning');
        return false;
    } 
    
     if ($.trim(txtMobile) != "") {
        if (CheckStr(txtMobile)) {
            $.messager.alert('系統提示', '手機號碼中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
   
    if ($.trim(ddlrole) =="") {
        $.messager.alert('系统提示', '請選擇角色！', 'warning');
        return false;
    }
    
    if($.trim(txtIP)=="")
    {
      $.messager.alert('系统提示', 'IP地址不能為空！', 'warning');
        return false;
    }
    
    if ($.trim(txtIP) != "") {
        if (CheckStr(txtIP)) {
            $.messager.alert('系統提示', 'IP中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
   
    $.post('../ashx/AddData.ashx',
           {
               'KeyValue': 'Users',
               'UserCode': txtUserCode
               
           },
            function(Return) {
                if (Return == "false") {
                    $.messager.alert('系統提示', '新增用戶出錯!', 'warning');
                }
                else if (Return == "Double") {
                    $.messager.alert('系統提示', '您要添加的用戶已經存在!', 'warning');
                }
                else {
                    iFrameContent.find('#btn_OK').click();
                }
            }
         )
}



/*
  修改用戶

*/
function AjaxForUserspd() {
    var iFrameContent =$("#subFrameUpd").contents();
    var txtUserCode = iFrameContent.find('#txtUserCode').val();
    var txtUserName = iFrameContent.find('#txtUserName').val();
    var txtPassword = iFrameContent.find('#txtPassword').val();
    var txtcfPassword = iFrameContent.find('#txtcfPassword').val();
    var txtTEL= iFrameContent.find('#txtTEL').val();
    var txtEmail = iFrameContent.find('#txtEmail').val();
    var txtMobile=iFrameContent.find('#txtMobile').val();
    var ddlrole = iFrameContent.find('#ddlrole').val();
    var txtIP=iFrameContent.find('#txtIP').val();
    var file = iFrameContent.find("#fileUpload").val();
    var pos = file.lastIndexOf("/");
    var ID = iFrameContent.contents().find('#lblID').val();
    if (pos == -1) {
        pos = file.lastIndexOf("\\");
    }
    var fuFileName = file.substr(pos + 1);
    
    if ($.trim(txtUserCode) == "") {
        $.messager.alert('系统提示', '用戶帳號不能爲空！', 'warning');
        return false;
    }
    
     if ($.trim(txtUserCode) != "") {
        if (CheckStr(txtUserCode)) {
            $.messager.alert('系統提示', '用戶帳號中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
    
    if ($.trim(txtUserName) == "") {
        $.messager.alert('系统提示', '用戶名稱不能為空！', 'warning');
        return false;
    }
    
    if ($.trim(txtUserName) != "") {
        if (CheckStr(txtUserName)) {
            $.messager.alert('系統提示', '用戶名稱中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
    
    if($.trim(txtPassword) != ""&& $.trim(txtPassword).length<6)
    {
          $.messager.alert('系统提示', '密碼長度不能小于6位數！', 'warning');
          return false;
    
    }
    
    if($.trim(txtPassword) != "")
    {       
          if($.trim(txtcfPassword) == "")
          {
              $.messager.alert('系统提示', '確認密碼不能為空！', 'warning');
              return false;
          }
    
    }
    
    if ($.trim(txtPassword) != "" && $.trim(txtcfPassword) != "") 
    {
      
       if($.trim(txtPassword)!=$.trim(txtcfPassword))
       {
          $.messager.alert('系统提示', '前后密碼不一致！', 'warning');
          return false;
       }
    }
    
    
    if ($.trim(txtPassword) != "") {
        if (CheckStr(txtPassword)) {
            $.messager.alert('系統提示', '用戶密碼中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
    
     
    if($.trim(fuFileName)!="")
    {
       if (CheckFile(fuFileName)) 
       {
        $.messager.alert('系統提示', '您只能上傳.jpg.gif.png.jpeg類型的圖片！', 'warning');
        return false;
      }   
    }
   
    if ($.trim(txtTEL) =="") {
        $.messager.alert('系统提示', '電話不能爲空！', 'warning');
        return false;
    }
     
    if ($.trim(txtTEL) != "") {
        if (CheckStr(txtTEL)) {
            $.messager.alert('系統提示', '電話號碼中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
     
    if ($.trim(txtEmail) =="") {
        $.messager.alert('系统提示', '郵箱不能爲空！', 'warning');
        return false;
    } 
    
    if ($.trim(txtEmail) != "") {
        if (CheckStrMail(txtEmail)) {
            $.messager.alert('系統提示', '郵箱地址中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
    
    if ($.trim(txtMobile) =="") {
        $.messager.alert('系统提示', '手機不能爲空！', 'warning');
        return false;
    } 
    
    if ($.trim(txtMobile) != "") {
        if (CheckStr(txtMobile)) {
            $.messager.alert('系統提示', '手機號碼中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
    
    if ($.trim(ddlrole) =="") {
        $.messager.alert('系统提示', '請選擇角色！', 'warning');
        return false;
    }
    
    if($.trim(txtIP)=="")
    {
      $.messager.alert('系统提示', 'IP不能為空！', 'warning');
        return false;
    }
    
     if ($.trim(txtIP) != "") {
        if (CheckStr(txtIP)) {
            $.messager.alert('系統提示', 'IP中不能包含@/\"#$%&^*！', 'warning');
            return false;
        }
    }
    
    
    $.post('../ashx/UpdateData.ashx',
           {
               'KeyValue': 'Users',
               'UserCode': txtUserCode,
               'ID'      :ID
               
           },
            function(Return) {
                if (Return == "false") {
                    $.messager.alert('系統提示', '更新用戶出錯!', 'warning');
                }
                else if (Return == "Double") {
                    $.messager.alert('系統提示', '用戶已經存在!', 'warning');
                }
                else {
                    iFrameContent.find('#btn_OK').click();
                }
            }
         )
    
}

/*
  查詢用戶
*/
function AjaxForMovieSearch(Url) {
    var iFrameContent = $("#subFrameSel").contents();
    var txtUserCode = iFrameContent.find('#txtUserCode').val();
    var txtUserName = iFrameContent.find('#txtUserName').val();
    var txtTEL = iFrameContent.find('#txtTEL').val();
    var txtEmail = iFrameContent.find('#txtEmail').val();
    var txtMobile = iFrameContent.find('#txtMobile').val();
    var ddlrole = iFrameContent.find('#ddlrole').val();
    var txtIP = iFrameContent.find('#txtIP').val();
    
    if (txtUserCode.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
       
    if (txtUserName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    
    if (txtTEL.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
       
    if (txtEmail.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
    
    if (txtMobile.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }
       
    if (txtIP.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }


    $.post('../ashx/SearchData.ashx',
            function(Return) {
                location.href = Url + "?SearchKey=" + escape(txtUserCode) + '=' +txtUserName + '='+txtTEL+'='+txtEmail+'='+txtMobile+'='+ddlrole+'='+txtIP+'&rand=' + Math.random();
                $('#WinSel').window('close');
            }
         )
}


///刪除電影動作 eidt by tanyi 2011-03-16
function DeleteClick(lblOperator) {
    var chk = $('tbody>tr>td').find(':checkbox')
    var chked = chk.filter(':checked');

    if (chked.length == 0) {
        $.messager.alert('系统提示', '請選擇要刪除的資料！', 'warning');
    }
    else {

        $.messager.confirm('系统提示', '您確定刪除嗎?',
                                            function(YesOrNO) {

                                                if (YesOrNO) {
                                                    getKeyValue(chked, lblOperator);
                                                }
                                            }
                                       );
    }
}


function getKeyValue(chked, lblOperator) {
    KeyValue = lblOperator.text();

    if (KeyValue == "") {
        $.messager.alert('系统提示', '缺少lblOperator控件！', 'warning');
        return;
    }
    for (i = 0; i < chked.length; i++) {
        KeyValue += "-" + chked[i].parentNode.nextSibling.innerHTML;

    }
    $.post('../ashx/DeleteData.ashx',
           { 'KeyValue': KeyValue },
            function(Return) {

                if (Return == "false") {
                    $.messager.alert('系统提示', '用戶刪除失敗！', 'show');
                }
                else {
                    location.href = Return;
                }

            })
}

/*
功能：上傳文件類型是否合法
開發人員：沈譚義
開發時間:2011-03-16
*/
function CheckFile(strFile) {
    var checkStr = ".jpg^.gif^.png^.jpeg^";
    var arrStr = checkStr.split('^');
    for (var i = 0; i < arrStr.length; i++) {
        if (strFile.toString().toLocaleLowerCase().indexOf(arrStr[i]) != -1) {
            return false;
        }
    }
    return true;
}

/*
功能:設置延遲鏈接頁面
開發人員：沈譚義
開發時間:2011-03-16
*/
function startRequest(Return) {
    parent.location.href = Return;
}

/*
功能:彈出提示窗口
開發人員：劉洪彬
開發時間:2011-03-16
*/
function AlertFlag(lblFlag) {
    if (lblFlag.text() == "Add") {
        $.messager.alert('系统提示', '用戶新增成功！', 'show');

    }
    if (lblFlag.text() == "Update") {
        $.messager.alert('系统提示', '用戶修改成功！', 'show');

    }
    if (lblFlag.text() == "Deleted") {
        $.messager.alert('系统提示', '用戶刪除成功！', 'show');
    }
}

/*
功能：字符串中有無特殊字符
開發人員：沈譚義
開發時間:2011-3-18
*/
function CheckStrMail(str) {
    var myReg = /^[^\/\'\\\"#$%&\^\*]+$/;


    if (myReg.test(str)) {
        return false;
    }
    return true;
}
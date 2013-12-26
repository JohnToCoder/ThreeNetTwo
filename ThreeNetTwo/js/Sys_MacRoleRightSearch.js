
$(document).ready(function() {
    $('#btnSel').click(function() {
        btnSearchClick();
    });

    $('#btnCancel').click(function() {
        closeWin();
    });

    $('#btnOk').click(function() {
        btnOkClick();
    })

})

//設置彈出層的參數值
function openwin(Title) {
    $('#Win').window({
        width: 400,
        modal: true,
        shadow: true,
        closed: true,
        height: 210,
        top: 100,
        left: 80,
        resizable: false,
        title: Title
    });
}

//打開層
function btnSearchClick() {
    openwin('查詢');
    $('#Win').css("display", "block");
    $('#Win').window('open');

    var iframe = $('#subFrame');
    var type = $("#txtType").val();
    iframe[0].src = "Sys_MacRoleRight_Edit.aspx";
}

//關閉彈出的層
function closeWin() {
    $('#Win').window('close');
}

//單擊彈出層中的確定按鈕觸發的事件
function btnOkClick() {
    var iFrameContent = $('#subFrame');

    var ddlMenuTypeID = iFrameContent.contents().find('#ddlMenuTypeID').val();
    var txtRoleID = $('#txtRoleID').val();
    var lblRoleName = $('#lblRoleName').text();

    AjaxForSysSearch(iFrameContent, '../../Manage/MacRoleRight/Sys_MacRoleRightAll.aspx?MenuId=' + ddlMenuTypeID + "&RoleID=" + txtRoleID + "&RoleName=" + lblRoleName);

}

function AjaxForSysSearch(iFrameContent, Url) {

    var ddlMenuTypeID = iFrameContent.contents().find('#ddlMenuTypeID').val();
    var ddlFlag = iFrameContent.contents().find('#ddlFlag').val();
    var txtName = iFrameContent.contents().find('#txtName').val();

    if (txtName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    $.post('../../ashx/SearchData.ashx',
    function(Retun) {
        location.href = Url + "&KeyValue=" + escape(ddlMenuTypeID) + '=' + escape(txtName) + '=' + escape(ddlFlag);
        closeWin();
    })
}

function DataDetail(strID, MenuTypeID) {

    var txtRoleID = $('#txtRoleID').val();
    var lblRoleName = $('#lblRoleName').text();
    var pageIndex = $("#txtPageIndex").val();
    var txtKeyValue = $('#txtKeyValue').val();

    switch (MenuTypeID) {

        //電視劇 
        case 10:
            parent.document.getElementById("frameShow").setAttribute("src", "../Manage/MacRoleRight/TVPlayDetail.aspx?strRoleName=" + lblRoleName + "&strID=" + strID + "&strMenuTypeID=" + MenuTypeID + "&strRoleID=" + txtRoleID + "&pageIndex=" + pageIndex + "&KeyValue=" + txtKeyValue);
            break;

        //音樂  
        case 11:
            parent.document.getElementById("frameShow").setAttribute("src", "../Manage/MacRoleRight/MusicDetail.aspx?strRoleName=" + lblRoleName + "&strID=" + strID + "&strMenuTypeID=" + MenuTypeID + "&strRoleID=" + txtRoleID + "&pageIndex=" + pageIndex + "&KeyValue=" + txtKeyValue);
            break;

        //相冊     
        case 12:
            parent.document.getElementById("frameShow").setAttribute("src", "../Manage/MacRoleRight/PhotoDetail.aspx?strRoleName=" + lblRoleName + "&strID=" + strID + "&strMenuTypeID=" + MenuTypeID + "&strRoleID=" + txtRoleID + "&pageIndex=" + pageIndex + "&KeyValue=" + txtKeyValue);
            break;
    }
}


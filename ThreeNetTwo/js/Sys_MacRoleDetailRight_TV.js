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


    //獲取當前頁碼索引 txtRoleName
    var pageIndex = $("#txtParentIndex").val();
    var txtMenuTypeId = $("#txtMenuTypeId").val();
    var txtRoleId = $("#txtRoleId").val();
    var txtRoleName = $("#txtRoleName").val();
    var txtKeyValue = $("#txtKeyValue").val();

    //返回按鈕事件
    ReturnEvent(txtRoleName, txtMenuTypeId, txtRoleId, pageIndex, txtKeyValue);

})

function ReturnEvent(strRoleName, strMenuTypeId, strRoleId, strPageIndex, strKeyValue) {
    $('#btnReturn').click(function() {
        parent.document.getElementById("frameShow").setAttribute("src", "../Manage/MacRoleRight/Sys_MacRoleRightAll.aspx?pageIndex=" + strPageIndex + "&RoleName=" + strRoleName + "&MenuId=" + strMenuTypeId + "&RoleID=" + strRoleId + "&KeyValue=" + strKeyValue);
    });
}

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

    var txtRightId = $("#txtRightId").val();
    var txtMenuTypeId = $("#txtMenuTypeId").val();
    var txtRoleId = $("#txtRoleId").val();

    iframe[0].src = "Sys_DetailRight_Edit.aspx?RightID=" + txtRightId + "&MenuTypeID=" + txtMenuTypeId + "&RoleID=" + txtRoleId;
}

//關閉彈出的層
function closeWin() {
    $('#Win').window('close');
}

//單擊彈出層中的確定按鈕觸發的事件
function btnOkClick() {

    var iFrameContent = $('#subFrame');

    var txtRightId = $('#txtRightId').val();
    var txtMenuTypeId = $('#txtMenuTypeId').val();
    var txtRoleId = $('#txtRoleId').val();

    var txtPageIndex = $("#txtParentIndex").val();
    var txtRoleName = $("#txtRoleName").val();
    var txtKeyValue = $("#txtKeyValue").val();

    AjaxForSysSearch(iFrameContent, '../../Manage/MacRoleRight/TVPlayDetail.aspx?strMenuTypeID=' + txtMenuTypeId + "&strRoleID=" + txtRoleId + "&strID=" + txtRightId + "&strRoleName=" + txtRoleName + "&pageIndex=" + txtPageIndex + "&KeyValue=" + txtKeyValue);

}

function AjaxForSysSearch(iFrameContent, Url) {

    var txtName = iFrameContent.contents().find('#txtName').val();

    if (txtName.indexOf('=') != -1) {
        $.messager.alert('系統提示', '輸入項不能包含特殊字符,如"="！', 'warning');
        return false;
    }

    $.post('../../ashx/SearchData.ashx',
    function(Retun) {
        location.href = Url + "&DetailKeyValue=" + escape(txtName);
        closeWin();
    })
}
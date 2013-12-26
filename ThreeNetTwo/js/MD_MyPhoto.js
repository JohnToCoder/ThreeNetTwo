/*
功能描述：我的相冊的相關功能實現
人員：胡貴 
時間：2011-03-14
*/
$(document).ready(function() {
    //Edit By Tanyi 圖片逐漸下載 2011.3.24
    $("img").lazyload({
        placeholder: "../images/grey.gif",
        effect: "fadeIn"
    });

    //查詢頁面及其確定與取消
    $('#btnSel').click(function() {
        openWinSel();
        var iFrameSel = $("#subFrameSel");
        iFrameSel[0].src = "../Photo/MD_Photos_Edit.aspx?flag=myphoto";
    });
    $('#btnSelYes').click(function() {
        AjaxForPhotoSel();
    });
    $('#btnCancel2').click(function() {
        $('#WinSel').window('close');
    });

});

function openWinSel() {
    $('#WinSel').window({
        width: 650,
        modal: true,
        shadow: true,
        closed: true,
        height: 380,
        top: 50,
        left: 80,
        resizable: false,
        title: ' 查詢窗口'
    });
    $('#WinSel').css("display", "block");
    $('#WinSel').window('open');
}


/*
MD_MyPhoto業務邏輯實現
*/
//查詢圖片
function AjaxForPhotoSel() {
    var iFrameContent = $("#subFrameSel").contents();

    var txtImageName = iFrameContent.find('#txtImageName').val();
    var ddlPictureCatalog = iFrameContent.find('#ddlPictureCatalog').val();
    var txtUserCode = iFrameContent.find('#txtUserCode').val();
    var txtServiceID = iFrameContent.find('#txtServiceID').val();

    $.post('../ashx/SearchData.ashx',
            function(Return) {
                location.href = "../Photo/MD_MyPhotos.aspx?SearchKey=" + txtImageName + "=" + ddlPictureCatalog + "=" + txtUserCode+"="+txtServiceID;
                $('#WinSel').window('close');
            }
         )
}
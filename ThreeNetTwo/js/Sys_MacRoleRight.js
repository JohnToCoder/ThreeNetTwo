
//楊碧清 2011-04-02
$(document).ready(function() {

    var RoleID = $('#txtRoleID').val();
    var RoleName = $('#txtRoleName').val();
    var menuTypeId = 8;//頻道

    $('#frameShow').attr('src', '../Manage/MacRoleRight/Sys_MacRoleRightAll.aspx?MenuId=' + menuTypeId + "&RoleID=" + RoleID + "&RoleName=" + escape(RoleName));

    $('.menu_title').eq(0).children().find('.STYLE1').addClass('ClickBg');

    $('.menu_title').each(function() {
        var menuTypeId = $(this).attr('title');

        $(this).click(function() {
            $('.ClickBg').removeClass('ClickBg');
            $(this).children().find('.STYLE1').addClass('ClickBg');

            SetChangePage(menuTypeId, RoleID, RoleName);
        });
    })

    $('#frameShow').height(parent.$('#WinQX').height());
})

//更具不同的資料類型，導入不同的頁面
function SetChangePage(menuTypeId, RoleID, RoleName) {

    switch (menuTypeId) {
        case "8":
        case "9":
        case "10":
        case "11":
        case "12":
            $('#frameShow').attr('src', '../Manage/MacRoleRight/Sys_MacRoleRightAll.aspx?MenuId=' + menuTypeId + "&RoleID=" + RoleID + "&RoleName=" + RoleName);
            break;
    }
} 

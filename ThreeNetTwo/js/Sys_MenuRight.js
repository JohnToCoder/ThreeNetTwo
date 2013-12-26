/*
開發人員：楊碧清
開發時間：2011-03-16
功能：角色的權限設置等功能的調用
*/
jQuery(document).ready(function() {

    var roleCode = $('#lblRoleCode').text(); //获得角色的Code

    $('#ttLeft').tree(
                    {
                        checkbox: true,
                        url: '../ashx/Sys_MenuRight.ashx?flag=1&RoleCodeId=' + roleCode
                        //url: 'TreeData.aspx'
                    }
                 );

    $('#ttRight').tree(
                    {
                        checkbox: true,
                        url: '../ashx/Sys_MenuRight.ashx?flag=2&RoleCodeId=' + roleCode
                        //url: 'TreeData.aspx'
                    }
                 );

    btnLeftClick(roleCode);
    btnRightClick(roleCode);
})

function btnLeftClick(roleCode) {

    $('#btnLeft').click(function() {
        getLeftChecked(roleCode);
    })
}

function btnRightClick(roleCode) {

    $('#btnRight').click(function() {
        getRightChecked(roleCode);
    })
}

function getLeftChecked(roleCode) {

    var nodes = $('#ttLeft').tree('getChecked1'); //获得选择左边的树的節點代碼(包含tree-checkbox1和tree-checkbox2)

    var nodes1 = $('#ttLeft').tree('getChecked'); //获得选择左边的树的節點代碼(只包含tree-checkbox1)

    var s = '';
    var s1 = '';

    for (var i = 0; i < nodes.length; i++) {
        if (s != '') s += ',';
        s += nodes[i].id;
    }

    for (var i = 0; i < nodes1.length; i++) {
        if (s1 != '') s1 += ',';
        s1 += nodes1[i].id;
    }

    $('#ttLeft').tree(
                {
                    checkbox: true,
                    url: '../ashx/Sys_MenuRight.ashx?flag=1&leftCode=' + s + '&RoleCodeId=' + roleCode + '&leftCode1=' + s1
                }
             );

    $('#ttLeft').tree('reload');

    $('#ttRight').tree(
                {
                    checkbox: true,
                    url: '../ashx/Sys_MenuRight.ashx?flag=2&RoleCodeId=' + roleCode
                }
             );
}

function getRightChecked(roleCode) {

    var nodes = $('#ttRight').tree('getChecked1'); //获得选择右边的树的图标(包含tree-checkbox1和tree-checkbox2)

    var nodes1 = $('#ttRight').tree('getChecked');  //获得选择右边的树的图标(只包含tree-checkbox1)

    var s = '';
    var s1 = '';

    for (var i = 0; i < nodes.length; i++) {
        if (s != '') s += ',';
        s += nodes[i].id;
    }

    for (var i = 0; i < nodes1.length; i++) {
        if (s1 != '') s1 += ',';
        s1 += nodes1[i].id;
    }

    $('#ttRight').tree(
                {
                    checkbox: true,
                    url: '../ashx/Sys_MenuRight.ashx?flag=2&rightCode=' + s + '&RoleCodeId=' + roleCode + '&rightCode1=' + s1
                }
             );

    $('#ttRight').tree('reload');

    $('#ttLeft').tree(
                {
                    checkbox: true,
                    url: '../ashx/Sys_MenuRight.ashx?flag=1&RoleCodeId=' + roleCode
                }
             );
}
		



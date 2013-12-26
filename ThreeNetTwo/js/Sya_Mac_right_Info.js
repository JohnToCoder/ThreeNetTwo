$(document).ready(function() {
    $('#moreProGramme').click(function() {
        btnClick("1");
    });

    $('#moreMovie').click(function() {
        btnClick("2");
    });

    $('#moreTvplay').click(function() {
        btnClick("3"); 
    });

    $('#moreMusic').click(function() {
        btnClick("4");
    });

    $('#morePhoto').click(function() {
        btnClick("5");
    });
})


function openwin(Title) {
    $('#WinMore').window({
        width: 685,
        modal: true,
        shadow: true,
        closed: true,
        height: 340,
        top: 20,
        left: 20,
        resizable: false,
        title: Title
    });
}

function btnClick(clickFlag) {
    openwin('更多信息');
    $('#WinMore').css("display", "block");
    $('#WinMore').window('open');

    var mac = $('#txtRole').val();
    var iframe = $('#subFrame');

    switch (clickFlag) {
        // "&addDate=" + addDate + "&MovieName=" + MovieName + "&TVDate=" + TVDate + "&Mname=" + Mname + "&Mdate=" + Mdate + "&MClass="+MClass);

        case "1":
            iframe[0].src = "../../Manage/MacRight/Sys_MacRight_Info_More.aspx?flag=1&mac=" + mac + "&class=" + "&playDate=" +
             "&MovieName=" + "&TVDate=" + "&Mname=" + "&Mdate=" + "&MClass=";
            break;
        case "2":
            iframe[0].src = "../../Manage/MacRight/Sys_MacRight_Info_More.aspx?flag=2&mac=" + mac + "&class=" + "&playDate=" +
             "&MovieName=" + "&TVDate=" + "&Mname=" + "&Mdate=" + "&MClass=";
            break;

        case "3":
            iframe[0].src = "../../Manage/MacRight/Sys_MacRight_Info_More.aspx?flag=3&mac=" + mac + "&class=" + "&playDate=" +
             "&MovieName=" + "&TVDate=" + "&Mname=" + "&Mdate=" + "&MClass=";
            break;
        case "4":
            iframe[0].src = "../../Manage/MacRight/Sys_MacRight_Info_More.aspx?flag=4&mac=" + mac + "&class=" + "&playDate=" +
             "&MovieName=" + "&TVDate=" + "&Mname=" + "&Mdate=" + "&MClass=";
            break;
        case "5":
            iframe[0].src = "../../Manage/MacRight/Sys_MacRight_Info_More.aspx?flag=5&mac=" + mac + "&class=" + "&playDate=" +
             "&MovieName=" + "&TVDate=" + "&Mname=" + "&Mdate=" + "&MClass=";
            break;
    }
} 

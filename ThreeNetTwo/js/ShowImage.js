/*
功能描述：異步調用Ashx程序加載本地圖片文件顯示
人員：胡貴 
時間：2011-03-14
*/
$(document).ready(function() {

    //1 .讀取本地圖片以流的方式顯示
    //2 .大小圖片切換瀏覽(需建立div)
    $('#Gv_Photo').find("tbody>tr>td>img").each(function() {

        var strImagePath = $(this).attr("src");
        $(this).attr("src", "../ashx/ShowImage.ashx?path=Photo&strId=" + strImagePath);

        $(this).click(function() {
            $('#ShowImage').css("display", "block");
            $('#imgBig').attr("src", "../ashx/ShowImage.ashx?path=Photo&strId=" + strImagePath);
        });
    });

    $('#Gv_MyPhoto').find("tbody>tr>td>img").each(function() {

        var strImagePath = $(this).attr("src");
        $(this).attr("src", "../ashx/ShowImage.ashx?path=Photo&strId=" + strImagePath);

        $(this).click(function() {
            $('#ShowImage').css("display", "block");
            $('#imgBig').attr("src", "../ashx/ShowImage.ashx?path=Photo&strId=" + strImagePath);
        });
    });

    $('#imgBig').click(function() {
        $('#ShowImage').css("display", "none");
    });

});

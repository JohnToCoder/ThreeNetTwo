
//抓取系統時間
function clock() {
    var now = new Date();
    var yy = now.getYear();
    var mm = now.getMonth() + 1;
    var dd = now.getDate();

    yy = (yy < 1900 ? (1900 + yy) : yy);
    dd = ((dd < 10) ? "0" + dd : dd);
    mm = ((mm < 10) ? "0" + mm : mm);

    document.getElementById('systime').innerHTML = yy + " 年 " + mm + " 月 " + dd + " 日  ";
}

/*
功能：上傳文件類型是否合法
開發人員：沈譚義
開發時間:2011-03-16
*/
function CheckFile(strFile) {
    var checkStr = ".jpg.gif.png.jpeg.bmp";
    
    //直接判斷文件結尾文件類型
    strFile = strFile.toString().toLocaleLowerCase().substring(strFile.toString().lastIndexOf("."), strFile.toString().length);

    if (checkStr.indexOf(strFile)!=-1) {
        return false;
    }
    return true;
}
/*
功能：驗證日期
開發人員：沈譚義
開發時間:2011-3-18
*/
function isDate(txtDate) {
    var regex = RegExp("^(?:(?:([0-9]{4}(-|\/)(?:(?:0?[1,3-9]|1[0-2])(-|\/)(?:29|30)|((?:0?[13578]|1[02])(-|\/)31)))|([0-9]{4}(-|\/)(?:0?[1-9]|1[0-2])(-|\/)(?:0?[1-9]|1\\d|2[0-8]))|(((?:(\\d\\d(?:0[48]|[2468][048]|[13579][26]))|(?:0[48]00|[2468][048]00|[13579][26]00))(-|\/)0?2(-|\/)29))))$");
    return regex;
}
/*
功能：字符串中有無特殊字符
開發人員：沈譚義
開發時間:2011-3-18
*/
function CheckStr(str) {
    var myReg = /^[^@\/\'\\\"#$%&\^\*]+$/;


    if (myReg.test(str)) {
        return false;
    }
    return true;
}
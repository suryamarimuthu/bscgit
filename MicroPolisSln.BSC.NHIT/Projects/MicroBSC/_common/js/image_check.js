
//파일의 확장자를 가져옮
function getFileExtension( filePath )
{
    var lastIndex = -1;
    lastIndex = filePath.lastIndexOf('.');
    var extension = "";

if ( lastIndex != -1 )
{
    extension = filePath.substring( lastIndex+1, filePath.len );
} else {
    extension = "";
}
    return extension;
}

//파일을 선택 후 포커스 이동시 호출
function uploadImg_Change( value )
{
    var src = getFileExtension(value);
    if (src == "") {
        alert('올바른 파일을 입력하세요');
        return;
    } else if ( !((src.toLowerCase() == "gif") || (src.toLowerCase() == "jpg") || (src.toLowerCase() == "jpeg")) ) {
        alert('gif 와 jpg 파일만 지원합니다.');
        return;
    }

    LoadImg( value);
}

function LoadImg(value)
{
    var imgInfo = new Image();
    imgInfo.onload = img_Load;
    imgInfo.src = value;
}

function img_Load()
{
    var imgSrc, imgWidth, imgHeight, imgFileSize;
    var maxFileSize; 
    maxFileSize = 500000;
    imgSrc = this.src;
    imgWidth = this.width;
    imgHeight = this.height;
    imgFileSize = this.fileSize;

    if (imgSrc == "" || imgWidth <= 0 || imgHeight <= 0)
    {
        alert('그림파일을 가져올 수 없습니다.');
        return;
    } 

    if (imgFileSize > maxFileSize)
    {
        alert('선택하신 그림 파일은 허용 최대크기인 ' + maxFileSize/1024 + ' KB 를 초과하였습니다.');
        return;
    } 

    //이미지 사이즈 저장 
    document.all.imgWidth.value = imgWidth;
    document.all.imgHeight.value = imgHeight;
}


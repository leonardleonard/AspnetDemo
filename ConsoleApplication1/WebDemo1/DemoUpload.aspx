<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemoUpload.aspx.cs" Inherits="WebDemo1.DemoUpload" %>




<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Upload</title>
    <link href="http://res.plures.net/lib/uploadify/3.2/uploadify.css" rel="stylesheet" />
    <link href="http://res.plures.net/lib/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        div.uploadify-button {
            font-weight:normal;
        }

        #imgPresent img {
            width: auto;
            height: auto;
            max-height: 100px;
            max-width: 300px;
            float: left;
        }
    </style>
</head>
<body>
    <div class="container-fluid">
        <h3><a href="http://www.uploadify.com/documentation/" target="_blank">jquery.uploadify</a></h3>
        <form method="post" action="/Demo/Upload">
            <div class="row-fluid">
                <div class="span1">
                    <label for="name">name:</label>
                </div>
                <div class="span11">
                    <input name="name" id="name" value="" />
                </div>
            </div>
            <div class="row-fluid">
                <div class="span1">
                    <label for="name">avatar:</label>
                </div>
                <div class="span11">
                    <input id="file_upload" name="file_upload" type="file">
                    <div id="imgPresent">
                    </div>
                </div>
            </div>
            <div class="row-fluid">
                <input type="submit" class="btn btn-primary" id="btnSubmit" value="提交" />
            </div>
        </form>
    </div>

    <script src="http://res.plures.net/lib/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
    <script src="http://res.plures.net/lib/jquery/1.9.1/jquery-migrate.min.js" type="text/javascript"></script>
    <script src="http://res.plures.net/lib/uploadify/3.2/jquery.uploadify.min.js" type="text/javascript"></script>
    <script src="http://res.plures.net/lib/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#file_upload").uploadify({
                buttonClass: "btn",
                buttonText: "选择图片",
                height: 24,
                width: 60,
                swf: 'http://res.plures.net/lib/uploadify/3.2/uploadify.swf',
                uploader: 'http://upload.plu.cn/upload.php?filename=file_upload&max_size=1048576&from=flash&format=json',
                multi: true,
                onUploadStart: function (file, data, response) {
                    $('#btnSubmit').prop('disabled', true);
                },
                onUploadSuccess: function (file, data, response) {
                    var result = eval("(" + data + ")");
                    if (result.success) {
                        var src = result.url;
                        var dom = '<img src="' + src + '"/>';
                        $($.parseHTML(dom)).appendTo('#imgPresent');
                    }
                },
                onQueueComplete: function () {
                    $('#btnSubmit').prop('disabled', false);
                }
            });
        });
    </script>
</body>
</html>

$(document).on("change", "#newProductImage", function () {

    var filesCount = $(this)[0].files.length;

    var textbox = $(this).prev();

    if (filesCount === 1) {
        var fileName = $(this).val().split("\\").pop();
        textbox.text(fileName);
    } else {
        textbox.text(filesCount + " files selected");
    }



    if (typeof (FileReader) != "undefined") {
        var dvPreview = $("#divImageMediaPreview");
        dvPreview.html("");
        $($(this)[0].files).each(function () {
            var file = $(this);
            var reader = new FileReader();
            reader.onload = function (e) {
                var img = $("<img />");
                img.attr("style", "object-fit: contain;margin-top: 7px;width:145px;height:125px;");
                img.attr("src", e.target.result);
                dvPreview.append(img);
            }
            reader.readAsDataURL(file[0]);
        });
    } else {
        alert("This browser does not support HTML5 FileReader.");
    }


});

$(document).on("change", "#newCagegoryImage", function () {


    var filesCount = $(this)[0].files.length;

    var textbox = $(this).prev();

    if (filesCount === 1) {
        var fileName = $(this).val().split("\\").pop();
        textbox.text(fileName);
    } else {
        textbox.text(filesCount + " files selected");
    }



    if (typeof (FileReader) != "undefined") {
        var dvPreview = $("#divImageMediaPreviewCategory");
        dvPreview.html("");
        $($(this)[0].files).each(function () {
            var file = $(this);
            var reader = new FileReader();
            reader.onload = function (e) {
                var img = $("<img />");
                img.attr("style", "object-fit: contain;margin-top: 7px;width:145px;height:125px;");
                img.attr("src", e.target.result);
                dvPreview.append(img);
            }
            reader.readAsDataURL(file[0]);
        });
    } else {
        alert("This browser does not support HTML5 FileReader.");
    }


});

$(document).ready(function () {
    $("#addProductForm").slideUp();
    $("#addCategoryForm").slideUp();
});


$("#addProductFormViewerBtn").click(function () {
    $("#addProductForm").slideDown();
    $("#addProductFormViewerBtn").hide();
}
);

$("#addProductForm .btn-outline-danger").click(function () {
    $("#addProductForm").slideUp();
    $("#addProductFormViewerBtn").show();

});

$("#addCategoryFormViewerBtn").click(function () {
    $("#addCategoryForm").slideDown();
    $("#addCategoryFormViewerBtn").hide();
}
);

$("#addCategoryForm .btn-outline-danger").click(function () {
    $("#addCategoryForm").slideUp();
    $("#addCategoryFormViewerBtn").show();

});







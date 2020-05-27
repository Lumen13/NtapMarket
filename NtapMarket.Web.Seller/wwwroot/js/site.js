// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var EditProduct = function (e) {
    var uploadedImages = e.target.uploadedImages;
    var formData = new FormData();

    for (var i = 0; i < uploadedImages.length; i++) {
        formData.append("uploadedImages", uploadedImages[i])
    }

    axios.post("Product/EditProduct", formData);
}

var DeleteImage = function (e) {
    alert("qw!!!!!!!eqwe");
}

var EditProduct = function (e) {
    var files = e.target.files;
    var formData = new FormData();

    for (var i = 0; i < files.length; i++) {

        //var keyName = `productModel.productImage${i}.imageFile`;
        //formData.append(keyName, files[i]);
        
        //elem.insertAdjacentHTML('beforebegin', ``)
    }    

    //axios.post("Edit", formData);
}

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#myImage')
                .attr('src', e.target.result);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

var DeleteImage = function (i) {
    for (var j = 0; j < document.body.children[1].firstElementChild.firstElementChild.children.length; j++) {
        if (document.body.children[1].firstElementChild.firstElementChild.children[j].className == i) {
            document.body.children[1].firstElementChild.firstElementChild.children[j].remove()
        } 
    }    
}

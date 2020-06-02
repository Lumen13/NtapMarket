function creater() {
    let inputClickCounter = 0
    function upload(element) {
        let file = element.files[0]
        const reader = new FileReader()

        reader.onloadend = loadImg
        function loadImg() {
            const button = document.createElement('button')
            const selector = `userDiv${inputClickCounter}`
            button.innerText = 'X'
            button.className = 'btn btn-danger'
            button.style.position = 'absolute'
            button.style.opacity = 0.7
            button.onclick = function () {
                const sl = `.${selector}`
                document.querySelector(sl).remove()
            }

            const img = document.createElement('img')
            img.style.height = '400px'
            img.style.width = '400px'
            img.src = reader.result

            const wraper = document.createElement('div')
            const wraperClass = selector
            wraper.classList.add(wraperClass)

            wraper.appendChild(button)
            wraper.appendChild(img)

            document.querySelector('.userImages').appendChild(wraper)
        }
        inputClickCounter++
        reader.readAsDataURL(file)
    }
    return upload
}

const imageUpload = creater()

var DeleteImage = function (i) {
    for (var j = 0; j < document.body.children[1].firstElementChild.firstElementChild.children.length; j++) {
        if (document.body.children[1].firstElementChild.firstElementChild.children[4].children[j].className === `dbImg-${i}`) {
            document.body.children[1].firstElementChild.firstElementChild.children[4].children[j].remove()
        }
    }
}

//var EditProduct = function (e) {
//    var files = e.target.files;
//    var formData = new FormData();

//    for (var i = 0; i < files.length; i++) {
//        var keyName = `productModel.productImage${i}.imageFile`;
//        formData.append(keyName, files[i]);
//    }

//    axios.post("Edit", formData);
//}
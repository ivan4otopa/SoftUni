var addNewSection = function addNewSection() {
    var title = document.getElementById("newSectionField").value;
    var newSection = new TODOList.Section(title);
    newSection.addToDOM();
};

var addNewItem = function addNewItem(target, inputId) {
    var content = document.getElementById(inputId).value;
    var newItem = new TODOList.Item(content);
    newItem.addToDOM(target);
};

var changeStatus = function changeStatus(target) {
    if (target.classList[1] == "checked") {
        target.className = "content";
    } else {
        target.className += " checked";
    }
};
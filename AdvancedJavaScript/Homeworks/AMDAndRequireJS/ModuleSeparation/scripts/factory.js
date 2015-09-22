define(['Container', 'Section', 'Item'], function (Container, Section, Item) {
    var factory = (function () {
        var addContainer = function (title) {
            var container = new Container(title);
            container.addToDOM();
        };

        var addNewSection = function addNewSection() {
            var title = document.getElementById("newSectionField").value;
            var newSection = new Section(title);
            newSection.addToDOM();
        };

        var addNewItem = function addNewItem(target, inputId) {
            var content = document.getElementById(inputId).value;
            var newItem = new Item(content);
            newItem.addToDOM(target);
        };

        var changeStatus = function changeStatus(target) {
            if (target.classList[1] == "checked") {
                target.className = "content";
            } else {
                target.className += " checked";
            }
        };

        return {
            addContainer: addContainer,
            addNewSection: addNewSection,
            addNewItem: addNewItem,
            changeStatus: changeStatus
        }
    }());

    return factory;
});
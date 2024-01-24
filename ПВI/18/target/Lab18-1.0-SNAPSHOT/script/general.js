let role;

function getRole() {
   if(role==null)
   {
       role="client";
   }
   else if(role=="client")
   {
       role="admin"
   }
   else
   {
       role="client";
   }
    visibilityButtons();
}

function visibilityButtons() {
    let buttons = `<input type="button" value="filter" onclick="visibilityFilterForm()">`;
    if (role == 'admin')
        buttons += `<input type="button" value="insert" onclick="visibilityInsertForm()">`
    document.getElementById('buttons').innerHTML = buttons;
    getReferences();
}

function visibilityInsertForm() {
    let form = `<p>Url:<input type="text" id="url"></p>
            <p>Description:<input type="text" id="description"></p>
            <p>
                <input type="button" onclick="addReference()" value="Add Reference">
                <input type="button" onclick="clearContent('form')" value="Cancel">
            </p>`
    document.getElementById("form").innerHTML = form;
}

function visibilityCommentsInsertForm(id) {
    let needId = "insertComment"+id;
    let form = `<p>Comment:<input type="text" id="comment"></p>
                <p>
                    <input type="button" onclick="addComment(${id})" value="Add comment">
                    <input type="button" value="Cancel" onclick="clearContent('insertComment${id}')">
                </p>`
    document.getElementById(needId).innerHTML = form;
}

function visibilityFilterForm() {
    let form = `<p>Description:<input type="text" id="filterDescription"></p>
                <p>
                    <input type="button" onclick="getReferences()" value="Filter">
                    <input type="button" onclick="clearContent('form')" value="Cancel">
                </p>`
    document.getElementById("form").innerHTML = form;
}

function updateContentVisibility(id,url,description) {
    let form = `<table>
                    <tr><td>
                        <p>Url:<input type="text" id="editUrl" value="${url}" ></p>
                        <p>Description:<input type="text" id="editDescription" value="${description}"></p>
                        <p>
                            <input type="button" onclick="updateReference(${id})" value="Update Reference">
                            <input type="button" value="Cancel" onclick="clearContent(${id})">
                        </p>
                    </td></tr>
            </table>`
    document.getElementById(id).innerHTML = form;
}

function deleteContentVisibility(id) {
    let attention = `<table>
                        <tr><td>
                            You sure to delete reference with id ${id} 
                            <input type="button" value="Yes" onclick="deleteReference(${id})">
                            <input type="button" value="Cancel" onclick="clearContent(${id})">
                        </td></tr>
                     </table>`;
    document.getElementById(id).innerHTML = attention;
}

function clearContent(id) {
    document.getElementById(id).innerHTML = "";
}

function runOnKeys(func, ...codes) {
    let pressed = new Set();

    document.addEventListener('keydown', function(event) {
        pressed.add(event.code);

        for (let code of codes) { // все ли клавиши из набора нажаты?
            if (!pressed.has(code)) {
                return;
            }
        }
        pressed.clear();

        func();
    });

    document.addEventListener('keyup', function(event) {
        pressed.delete(event.code);
    });

}

runOnKeys(
    () => getRole(),
    "KeyA",
    "KeyD",
    "KeyM"
);

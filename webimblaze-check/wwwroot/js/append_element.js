<!--Append an element -- >
var parentDiv = document.getElementById("magicalegg");
var newParagraph = document.createElement("p");
var t = document.createTextNode("But this paragraph came from JavaScript.");
newParagraph.appendChild(t);
parentDiv.appendChild(newParagraph);


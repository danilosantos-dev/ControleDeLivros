// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


let table = new DataTable('table.display');



$(document).ready(function () {
	setTimeout(function () {
		$(".alert").fadeOut("slow", function () {
			$(this).alert('close');
		});
	}, 3000);
});
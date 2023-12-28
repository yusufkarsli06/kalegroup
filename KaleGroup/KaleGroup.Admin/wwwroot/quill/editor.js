var t = new Quill("#editor2", {
    modules: {
        toolbar: [
            ["bold", "italic", "underline"],
            [{ header: 1 }, { header: 2 }],
            [{ header: [1, 2, 3, 4, 5, 6, !1] }],
            [{ indent: "-1" }, { indent: "+1" }],
            [{ align: [] }],
            ["clean"],
        ],
    },
    theme: "snow",
});
t.on("text-change", function () {
    var html = t.root.innerHTML;
    $("#DocumentHtml").val(html);
});
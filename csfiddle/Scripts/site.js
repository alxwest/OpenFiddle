$(document).ready(function () {
    csfiddle = {
        editor: CodeMirror.fromTextArea(document.getElementById('InputCode'), {
            lineNumbers: true,
            matchBrackets: true,
            mode: "text/x-csharp",
            indentUnit: 4,
            autofocus: true
        }),

        runCode: function() {
            $("#run").html("Running...");
            $.post('/Run', { InputCode: csfiddle.editor.getValue() }, function(data) {
                $('#result').html("<pre>" + data + "</pre>");
            })
                .always(function () { $("#run").html("Run"); })
                .fail(function () { $("#result").html("<pre>Failed to run.</pre>"); });
        },

        saveCode: function () {
            $("#save").html("Saving...");
            $.post('/Save', { Id: $("#id").val(), InputCode: csfiddle.editor.getValue() }, function(id) {
                if ($("#id").val() != id) {
                    history.pushState(null, "Viewing Fiddle " + id, "/" + id);
                    $("#id").val(id);
                }
            }).always(function() { $("#save").html("Save"); });
        }
    };
    
    $('body').layout({
        resizeWhileDragging: true,
        sizable: false,
        animatePaneSizing: true,
        west__size: "50%",
        spacing_open: 0,
        spacing_closed: 0,
        west__spacing_closed: 8,
        west__spacing_open: 8,
        west__togglerLength_closed: 105,
        west__togglerLength_open: 105,
        closable: false
    });

    $("#new").click(function () { window.location = ""; });
    $("#run").click(csfiddle.runCode);
    $("#save").click(csfiddle.saveCode);
});
// This file is required by the index.html file and will
// be executed in the renderer process for that window.
// All of the Node.js APIs are available in this process.

var spa = function () {
    require("./wwwroot/js/jquery.js");
    require("./wwwroot/js/npmlibs/core-js/shim.min.js");
    require("./wwwroot/js/npmlibs/zone.js/zone.js");
    require("./wwwroot/js/npmlibs/reflect-metadata/Reflect.js");
    require("./wwwroot/js/npmlibs/systemjs/system.src.js");
    require("./system.config.js");
    require("./wwwroot/js/bootstrap.js");
    require("./wwwroot/js/jquery.fancybox.pack.js");
    require("./wwwroot/js/alertify.min.js");
    System.import('app').catch(console.log.bind(console));
    $(document).ready(function () {
        $('.fancybox').fancybox();
    });
};



spa();




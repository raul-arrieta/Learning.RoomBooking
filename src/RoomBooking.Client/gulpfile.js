var gulp = require('gulp'),
    electron = require('electron-connect').server.create(),
    ts = require('gulp-typescript'),
    del = require('del'),
    gutil = require('gulp-util');

var paths = {
    npmSrc:     './node_modules/',
    frontSrc:   '../RoomBooking.Front/wwwroot/',
    wwwroot:    './wwwroot/',
    tsSource:   './wwwroot/app/**/*.ts',
    tsOutput:   './wwwroot/spa/',
    js:         './wwwroot/js',
    libOutput:  './wwwroot/js/npmlibs/',
    cssOutput:  './wwwroot/css',
    imgOutput:  './wwwroot/img',
    fontsOutput:'./wwwroot/fonts'
};

gulp.task('clean', function () {
    del(paths.wwwroot + '/**', { force: true });
    return;
});

gulp.task('copy-front', ['clean'], function () {
    gutil.log("Importing front...");
    return gulp.src(paths.frontSrc + '**/*.*', { base: paths.frontSrc }).pipe(gulp.dest(paths.wwwroot));
});

gulp.task('compile-typescript', ['copy-front'], function () {
    var tsProject = ts.createProject('./wwwroot/tsconfig.json');
    var tsResult = gulp.src('wwwroot/app/**/*.ts')
        .pipe(ts(tsProject), undefined, ts.reporter.fullReporter());
    return tsResult.js.pipe(gulp.dest(paths.tsOutput));
});


gulp.task('copy-dependencies', ['compile-typescript'], function () {
    gutil.log("Copying dependencies...");
    gutil.log("+ libs...");

    gutil.log("     · jquery");
    gulp.src('node_modules/jquery/dist/jquery.*js')
        .pipe(gulp.dest(paths.js));
    gutil.log("     · bootstrap");
    gulp.src('bower_components/bootstrap/dist/js/bootstrap*.js')
        .pipe(gulp.dest(paths.js));
    gutil.log("     · fancybox");
    gulp.src('node_modules/fancybox/dist/js/jquery.fancybox.pack.js')
        .pipe(gulp.dest(paths.js));
    gutil.log("     · alertify");
    gulp.src('bower_components/alertify.js/lib/alertify.min.js')
        .pipe(gulp.dest(paths.js));
    gutil.log("     · systemjs");
    gulp.src(paths.npmSrc + 'systemjs/dist/**/*.*', { base: paths.npmSrc + 'systemjs/dist/' })
        .pipe(gulp.dest(paths.libOutput + 'systemjs/'));
    gutil.log("     · core-js");
    gulp.src(paths.npmSrc + 'core-js/client/*', { base: paths.npmSrc + 'core-js/client/' })
        .pipe(gulp.dest(paths.libOutput + 'core-js/'));
    gutil.log("     · rxjs");
    gulp.src(paths.npmSrc + 'rxjs/**', { base: paths.npmSrc + 'rxjs/' })
        .pipe(gulp.dest(paths.libOutput + 'rxjs/'));
    gutil.log("     · zone.js");
    gulp.src(paths.npmSrc + 'zone.js/dist/*.*', { base: paths.npmSrc + 'zone.js/dist/' })
        .pipe(gulp.dest(paths.libOutput + 'zone.js/'));
    gutil.log("     · reflect-metadata");
    gulp.src(paths.npmSrc + 'reflect-metadata/*.js', { base: paths.npmSrc + 'reflect-metadata/' })
        .pipe(gulp.dest(paths.libOutput + 'reflect-metadata/'));
    gutil.log("     · angular2-in-memory-web-api");
    gulp.src(paths.npmSrc + 'angular2-in-memory-web-api/*.*', { base: paths.npmSrc + 'angular2-in-memory-web-api/' })
        .pipe(gulp.dest(paths.libOutput + 'angular2-in-memory-web-api/'));
    gutil.log("     · @angular2");
    gulp.src([paths.npmSrc + '@angular/**'], { base: paths.npmSrc + '@angular/' })
        .pipe(gulp.dest(paths.libOutput + '@angular/'));

    gutil.log("+ css...");
    gulp.src([
        'bower_components/bootstrap/dist/css/bootstrap.css',
        'node_modules/fancybox/dist/css/jquery.fancybox.css',
        'bower_components/components-font-awesome/css/font-awesome.css',
        'bower_components/alertify.js/themes/alertify.core.css',
        'bower_components/alertify.js/themes/alertify.bootstrap.css',
        'bower_components/alertify.js/themes/alertify.default.css'
    ]).pipe(gulp.dest(paths.cssOutput));

    gutil.log("+ imgs...");
    gulp.src([
        'node_modules/fancybox/dist/img/blank.gif',
        'node_modules/fancybox/dist/img/fancybox_loading.gif',
        'node_modules/fancybox/dist/img/fancybox_loading@2x.gif',
        'node_modules/fancybox/dist/img/fancybox_overlay.png',
        'node_modules/fancybox/dist/img/fancybox_sprite.png',
        'node_modules/fancybox/dist/img/fancybox_sprite@2x.png'
    ]).pipe(gulp.dest(paths.imgOutput));

    gutil.log("+ fonts...");
    gulp.src([
        'node_modules/bootstrap/fonts/glyphicons-halflings-regular.eot',
        'node_modules/bootstrap/fonts/glyphicons-halflings-regular.svg',
        'node_modules/bootstrap/fonts/glyphicons-halflings-regular.ttf',
        'node_modules/bootstrap/fonts/glyphicons-halflings-regular.woff',
        'node_modules/bootstrap/fonts/glyphicons-halflings-regular.woff2',
        'bower_components/components-font-awesome/fonts/FontAwesome.otf',
        'bower_components/components-font-awesome/fonts/fontawesome-webfont.eot',
        'bower_components/components-font-awesome/fonts/fontawesome-webfont.svg',
        'bower_components/components-font-awesome/fonts/fontawesome-webfont.ttf',
        'bower_components/components-font-awesome/fonts/fontawesome-webfont.woff',
        'bower_components/components-font-awesome/fonts/fontawesome-webfont.woff2'
    ]).pipe(gulp.dest(paths.fontsOutput));

});

    
gulp.task('run', ['copy-dependencies'], function () {

    // Start browser process 
    electron.start();

    // Restart browser process 
    gulp.watch('app.js', electron.restart);

    // Reload renderer process 
    gulp.watch(['index.js', 'index.html'], electron.reload);
});



var gulp        = require('gulp');
var sass        = require('gulp-sass');
var browserSync = require('browser-sync').create();
var path        = require('path');


gulp.task('default', function() {

    //proxy dev server
    browserSync.init({
        proxy: "localhost:5000"
    });

    //process sass and stream css changes
    gulp.watch('wwwroot/css/*.scss', function() {
        gulp.src('wwwroot/css/*.scss')
            .pipe(sass({
                includePaths: ['./node_modules/compass-mixins/lib']
            }).on('error', sass.logError))
            .pipe(gulp.dest('wwwroot/css'))
            .pipe(browserSync.stream()); 
    });


    //reload on all code changes
    gulp.watch(['**/*.cshtml','wwwroot/**/*.js', '**/*.cs'] , function() {
        browserSync.reload();
    });


  

    

    

});


let gulp = require('gulp')
let del = require('del')
let htmlMin = require('gulp-htmlmin')

gulp.task('html', function () {
  del.sync(['build/allhtml*'])

  return gulp.src('*.html')
    .pipe(htmlMin({ collapseWhitespace: true }))
    .pipe(gulp.dest('build'))
})

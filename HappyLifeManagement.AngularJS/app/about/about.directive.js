'use strict';

var app = angular.module('myApp');

app.directive('aboutLink', function () {
    return {
        restrict: 'E',
        templateUrl: 'app/about/about.directive.view.html',
        controller: function ($scope, ngDialog) {

            $scope.sayHi = function ($event) {
                $event.preventDefault();

                ngDialog.open({ template: 'app/about/popupTmpl.html', className: 'ngdialog-theme-default' });

                //ngDialog.open({ template: 'templateId' });
            }
        },
        replace: true
    }
});
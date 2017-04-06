'use strict';
 
var app = angular.module('myApp');

app.controller('NoteController', NoteController);

NoteController.$inject = ['$scope', '$http', 'NoteService'];

function NoteController($scope, $http, NoteService) {

    $scope.total = 0;
    $scope.page = 1;

    NoteService.GetNotes().success(function (response) {
        $scope.notes = response.items;

        $scope.page = response.page;
        $scope.total = response.totalItemCount;
    });

    $scope.GetNotePagings = function (page) {
        NoteService.GetNotePagings(page).success(function (response) {
            $scope.notes = response.items;
        });
    };
}
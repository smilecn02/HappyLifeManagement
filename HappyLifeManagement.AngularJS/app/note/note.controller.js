'use strict';
 
var app = angular.module('myApp');

app.controller('NoteController', NoteController);

NoteController.$inject = ['$scope', '$http', 'NoteService', 'blockUI'];

function NoteController($scope, $http, NoteService, blockUI) {

    $scope.total = 0;
    $scope.page = 1;

    blockUI.start();

    NoteService.GetNotes().success(function (response) {
        $scope.notes = response.items;

        $scope.page = response.page;
        $scope.total = response.totalItemCount;

        blockUI.stop();
    });

    $scope.GetNotePagings = function (page) {
        blockUI.start();
        NoteService.GetNotePagings(page).success(function (response) {
            $scope.notes = response.items;
            blockUI.stop();
        });
    };
}
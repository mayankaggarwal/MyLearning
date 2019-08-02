(function () {
    'use strict';
    function fileUploadController(fileUploadService) {
        var self = this;
        self.files = [];
        self.selectedFile = null;
        self.uploadFile = function () {
            var file = $scope.myFile;
            var uploadUrl = "../server/service.php", //Url of webservice/api/server
                promise = fileUploadService.uploadFileToUrl(file, uploadUrl);

            promise.then(function (response) {
                $scope.serverResponse = response;
            }, function () {
                $scope.serverResponse = 'An error has occurred';
            });
        };

        self.testApi = function () {

            var promise = fileUploadService.testTestApi();
            promise.then(function (result) {
                console.log(result);
            }, function (error) {
                console.log(error);
            });
        };

        self.getFiles = function () {
            var promise = fileUploadService.getListFiles();
            promise.then(function (result) {
                self.files = result;
            }, function (error) {
                console.log(error);
            });
        }

        self.downloadFile = function () {
            var fileName = self.selectedFile;
            if (!!fileName) {
                console.log(fileName);
                var promise = fileUploadService.getFile(fileName);
                promise.then(function (result) {
                    headers = result.headers();

                    var filename = headers['x-filename'];
                    var contentType = headers['content-type'];

                    var linkElement = document.createElement('a');
                    try {
                        var blob = new Blob([result.data], { type: contentType });
                        var url = window.URL.createObjectURL(blob);

                        linkElement.setAttribute('href', url);
                        linkElement.setAttribute("download", filename);

                        var clickEvent = new MouseEvent("click", {
                            "view": window,
                            "bubbles": true,
                            "cancelable": false
                        });
                        linkElement.dispatchEvent(clickEvent);
                    } catch (ex) {
                        console.log(ex);
                    }
                }, function (error) {
                    console.log(error);
                });
            }
        }

        

        self.getFiles();
    }

    var mod = angular.module("fupApp");
    mod.controller('funController', ["fileUploadService", fileUploadController]);

})();
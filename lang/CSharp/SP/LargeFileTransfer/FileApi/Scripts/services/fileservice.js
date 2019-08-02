(function () {
    'use strict';
    var baseUrl = "/filestreaming";
    var apiEndpoints = {
        "BASE": baseUrl,
        "TEST": baseUrl + "/test",
        "LISTFILES": baseUrl + "/files",
        "DOWNLOADFILE":baseUrl + "/files/{filename}"
    };
    function fileapiService(fileServiceEndpoints, $http, $q) {
        var self = this;
        self.uploadFileToUrl = function (file, uploadUrl) {
            //FormData, object of key/value pair for form fields and values
            var fileFormData = new FormData();
            fileFormData.append('file', file);

            var deffered = $q.defer();
            $http.post(uploadUrl, fileFormData, {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }

            }).success(function (response) {
                deffered.resolve(response);

            }).error(function (response) {
                deffered.reject(response);
            });

            return deffered.promise;
        };

        self.testTestApi = function () {
            var url = fileServiceEndpoints.TEST;
            var deffered = $q.defer();
            $http.get(url)
                .success(function (response) {
                    deffered.resolve(response);

                }).error(function (response) {
                    deffered.reject(response);
                });

            return deffered.promise;
        };

        self.getListFiles = function () {
            var url = fileServiceEndpoints.LISTFILES;
            var deffered = $q.defer();
            $http.get(url)
                .success(function (response) {
                    deffered.resolve(response);
                }).error(function (response) {
                    deffered.reject(response);
                });

            return deffered.promise;
        }

        self.getFile = function (fileName) {
            var url = fileServiceEndpoints.DOWNLOADFILE.replace("{filename}", fileName);
            var deffered = $q.defer();
            $http.get(url)
                .success(function (data,status,headers) {
                    deffered.resolve({data:data,status:status,headers:headers});
                }).error(function (response) {
                    deffered.reject(response);
                });
            return deffered.promise;
        }


    }

    var mod = angular.module('fupApp');
    mod.constant("FILESERVICE_ENDPOINTS", apiEndpoints);
    mod.service("fileUploadService", ["FILESERVICE_ENDPOINTS", "$http", "$q", fileapiService]);
})();
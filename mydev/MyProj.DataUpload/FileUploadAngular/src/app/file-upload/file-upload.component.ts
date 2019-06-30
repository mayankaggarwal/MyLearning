import { Component, OnInit } from '@angular/core';
import { FileUploadService }  from './file-upload.service';
import { FileToUpload }  from './file-to-upload';
const MAX_SIZE: number = 1048576;

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent implements OnInit {
  theFiles: any[] =[];
  messages: string[] = [];
  constructor(private uploadService:  FileUploadService) { }

  ngOnInit() {
  }

  onFileChange(event) {
    this.theFiles = [];
        
    // Any file(s) selected from the input?
    if (event.target.files &&
        event.target.files.length > 0) {
      for (let index = 0;
               index < event.target.files.length;
               index++) {
        let file = event.target.files[index];
        // Don't allow file sizes over 1MB
        if (file.size < MAX_SIZE) {
          // Add file to list of files
          this.theFiles.push(file);
        }
        else {
          this.messages.push("File: " + file.name
             + " is too large to upload.");
        }
      }
    }
  }

  uploadFile(): void {
    for (let index = 0;
             index < this.theFiles.length;
             index++) {
      this.readAndUploadFile(this.theFiles[index]);
    }
  }

  private readAndUploadFile(theFile: any) {
    let file = new FileToUpload();
        
    // Set File Information
    file.fileName = theFile.name;
    file.fileSize = theFile.size;
    file.fileType = theFile.type;
    file.lastModifiedTime = theFile.lastModified;
    file.lastModifiedDate = theFile.lastModifiedDate;
        
    // Use FileReader() object to get file to upload
    // NOTE: FileReader only works with newer browsers
    let reader = new FileReader();
        
    // Setup onload event for reader
    reader.onload = () => {
      // Store base64 encoded representation of file
      file.fileAsBase64 = reader.result.toString();
        
      // POST to server
      this.uploadService.uploadFile(file)
        .subscribe(resp =>
          { this.messages.push("Upload complete"); });
    }
        
    // Read the file
    reader.readAsDataURL(theFile);
  }

}

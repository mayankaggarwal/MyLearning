import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class QuizService {
//------------------- Properties ------------
readonly rootUrl = 'http://localhost:65447/';
qns : any[];
seconds:number;
timer;
qnProgress:number;
correctAnswerCount:number = 0;

//------------------- Helper Methods --------

  constructor(private httpClient:HttpClient) { }
  displayTimeElapsed(){
    return Math.floor(this.seconds/3600) + ":" + Math.floor(this.seconds/60) + Math.floor(this.seconds%60);
  }


//------------------- Http Methods ----------
insertParticipant(name:string,email:string){
  var body = {
    Name:name,
    Email:email
  }
  return this.httpClient.post(this.rootUrl + '/api/Participant',body);
}

getQuestions(){
  return this.httpClient.get(this.rootUrl + '/api/Questions');
}

getAnswers(){
  var body = this.qns.map(x=>x.QnID);
  return this.httpClient.post(this.rootUrl + '/api/Answers',body);
}

getParticipantName(){
  var participant = JSON.parse(localStorage.getItem('participant'));
  return participant.Name;
}

submitScore(){
  var body = JSON.parse(localStorage.getItem('participant'));
  body.Score = this.correctAnswerCount;
  body.TimeSpent = this.seconds;
  return this.httpClient.put(this.rootUrl + '/api/Participant',body);
}
}

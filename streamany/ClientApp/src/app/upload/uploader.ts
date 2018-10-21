import { UploadQueue } from '../upload/uploadqueue';

export class Uploader {
  queue: UploadQueue[];

  constructor() {
    this.queue = [];
  }
}

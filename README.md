## API Integration Notes & Assumptions

### Background Removal API

The application uses the **Remove Background API** provided by **DeepAI** for automatic background removal.

Workflow:

1. The user captures a photo using the webcam.
2. The captured image is sent to the background removal API.
3. The API processes the image and returns a background-removed version.
4. The processed image is then displayed in the preview frame.

Assumptions:

* A stable internet connection is required for API processing.
* API requests may take a few seconds depending on network speed and server response time.
* If the API fails, the application displays an error message and allows the user to retry.

---

### Image Hosting & QR Code Sharing

The application uploads the final processed image to **Cloudinary** for public access and sharing.

Workflow:

1. After successful background removal, the final image is saved locally.
2. The same image is uploaded to **Cloudinary** using an unsigned upload preset.
3. Cloudinary returns a public image URL.
4. A QR code is generated from this URL.
5. Users can scan the QR code on a mobile device to download or view the photo.

Assumptions:

* The Cloudinary free tier is sufficient for this demo application.
* The upload preset is configured as **unsigned** for simplicity and ease of integration.
* Uploaded images are publicly accessible via the generated URL.

---

### Local Storage

Captured and processed images are also stored locally using Unity's persistent data path.

Purpose:

* Display images in the local gallery.
* Maintain a history of previously captured photos.

Gallery Behavior:

* The newest images appear first in the gallery.
* Images are loaded dynamically when the Home page is opened.

---

### Design Decisions

* The application follows a **capture → preview → confirm → process → share** workflow to allow users to review photos before processing.
* Background removal occurs **only after the user confirms the captured photo**, preventing unnecessary API calls.
* The final processed image (not the raw capture) is the version shared via QR code.

---

### Limitations

* The application relies on external APIs for background removal and cloud storage.
* API rate limits or network issues may affect processing time.
* Security for image uploads is simplified for demonstration purposes.

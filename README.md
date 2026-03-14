## API Integration Notes & Assumptions

### Background Removal API

The application integrates the **remove.bg API** for automatic background removal.

Workflow:

1. The user captures a photo using the webcam.
2. The captured image is temporarily stored in memory and shown in a preview screen.
3. Once the user confirms the photo, the image is sent to the **remove.bg API**.
4. The API processes the image and returns a version with the background removed.
5. The processed image is then displayed to the user and used as the final result.

Notes:

* Background removal occurs **only after the user confirms the captured photo**, reducing unnecessary API calls.
* The API response is received as image data and converted back into a `Texture2D` inside Unity.
* Processing time may vary depending on network speed and API response time.

---

### Image Upload & Sharing

To enable photo downloads on mobile devices, the final processed image is uploaded to **Cloudinary**.

Workflow:

1. After successful background removal, the processed image is saved locally.
2. The same image is uploaded to Cloudinary using an **unsigned upload preset**.
3. Cloudinary returns a publicly accessible image URL.
4. A QR code is generated from this URL.
5. Users can scan the QR code on a mobile device to download or view the photo.

Notes:

* The Cloudinary free tier is sufficient for this demonstration project.
* Uploaded images are publicly accessible through the generated URL.

---

### Local Storage & Gallery

All processed photos are also stored locally using Unity's **persistent data path**.

Purpose:

* Maintain a local archive of captured photos.
* Display previously captured photos in the gallery section of the home page.

Gallery Behavior:

* Images are loaded dynamically when the Home page is opened.
* The **most recent photo appears first**, while older photos appear later.
* Duplicate UI elements are prevented by clearing existing gallery items before reloading.

---

### Application Workflow

The application follows a structured user flow:

Capture Photo → Preview Photo → Confirm → Background Removal → Upload Image → Generate QR Code → Share / Download

This flow ensures the user can review the photo before processing and prevents unnecessary API requests.

---

### Assumptions

* A stable internet connection is required for API processing and image upload.
* API response time depends on network speed and external service availability.
* For simplicity, image uploads are configured using an unsigned upload preset on Cloudinary.

---

### Limitations

* The application depends on external APIs (remove.bg and Cloudinary).
* Network issues or API limits may affect processing time.
* Security configuration for cloud uploads is simplified for demonstration purposes.

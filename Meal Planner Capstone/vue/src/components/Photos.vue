<template>
  <!-- eslint-disable --> <!-- This disables annoying eslink warning messages in the html       -->
    <!-- This is the dropzone component that will give a place to drop the image to be uploaded -->
    <!-- there are two custom events the component listens for:                                 -->
    <!--       the vdropzone-sending event which is fired when dropzone is sending an image     -->
    <!--       the vdropzone-success event which is fired when dropzone upload is successful    -->
    <vue-dropzone
        id="dropzone"
        class="mt-3"
        v-bind:options="dropzoneOptions"
        v-on:vdropzone-sending="addFormData"
        v-on:vdropzone-success="getSuccess"
        :useCustomDropzoneOptions="true"
    ></vue-dropzone>
</template>


<script>
/* eslint-disable */
import vue2Dropzone from "vue2-dropzone";
import "vue2-dropzone/dist/vue2Dropzone.min.css";

export default {
    name: "upload-photo",
    components: {
        vueDropzone: vue2Dropzone
    },
    data(){
        return {
            // TODO: Add imgUrl to Recipe object
            imgUrl: '',
            dropzoneOptions: {
                url: "https://api.cloudinary.com/v1_1/dy5vryv7m/image/upload",  
                thumbnailWidth: 250,
                thumbnailHeight: 250,
                maxFilesize: 2.0,
                acceptedFiles: ".jpg, .jpeg, .png, .gif",
                uploadMultiple: false,
                addRemoveLinks: true,
                dictDefaultMessage: 'Add a photo for your recipe. </br> Drop files here to upload or click to select a file for upload.',                
            },      
        }
    },

    methods:{
        /******************************************************************************************
         * The addFormData method is called when vdropzone-sending event is fired
         * it adds additional headers to the request
         ******************************************************************************************/
        addFormData(file, xhr, formData) {
            formData.append("api_key", "654255138794743");  // substitute your api key
            formData.append("upload_preset", "av5w3cm0");   // substitute your upload preset
            formData.append("timestamp", (Date.now() / 1000) | 0);
            formData.append("tags", "vue-app");
        },
         /******************************************************************************************
         * The getSuccess method is called when vdropzone-success event is fired
         ******************************************************************************************/
        getSuccess(file, response) {
            this.imgUrl = response.secure_url;   // store the url for the uploaded image
            this.$emit("image-upload", imgUrl);   // fire custom event with image url in case someone cares
        },
    }
}
</script>

<style scoped>
#dropzone{
    width: 60%;
    margin-left: auto;
    margin-right: auto;
    border-radius: 12px;
}

#dropzone:hover{
    background: rgb(253, 189, 69);
    transition-delay: 0.2s;
    box-shadow: 0 12px 16px 0 rgba(0,0,0,0.24), 0 17px 50px 0 rgba(0,0,0,0.19);
}

</style>



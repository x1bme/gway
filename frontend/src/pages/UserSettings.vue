<template>
 <q-page class="flex -direction column items-start">
    <div class="q-pa-md">
      <div class="text-h6">User Profile</div>
      <q-form @submit.prevent="onSubmit">
        <q-file-input outlined v-model="userProfile.profilePicture" label="Upload Profile Picture" accept=".jpg,.
jpeg,.png" />
        <q-select filled v-model="userProfile.role" :options="roles" label="Role" />
        <q-input outlined v-model="userProfile.firstName" label="First Name" />
        <q-input outlined v-model="userProfile.lastName" label="Last Name" />
        <q-input outlined v-model="userProfile.email" label="Email" />
        <q-btn label="Update Profile" type="submit" color="primary" />
      </q-form>
    </div>
 </q-page>
</template>

<script>
export default {
 data () {
    return {
      userProfile: {
        profilePicture: null,
        role: '',
        firstName: '',
        lastName: '',
        email: ''
      },
      roles: ['Network Administrator', 'MOV Program Engineer', 'Field Service Technician (FST)', 'Field Service Engineer (FSE)', 'Other']
    }
 },
 methods: {
    onSubmit() {
      console.log('Profile updated:', this.userProfile);
      // Implement logic to update the user profile
    }
},
};
</script>

<style scoped>
.q-page {
 padding: 20px;
}

.q-form {
 max-width: 600px;
 margin: auto;
}

.q-input,.q-select,.q-file-input {
 margin-bottom: 20px;
}
</style>

<script setup lang="ts">
  import { useAppNotFoundPage } from '~/utils/domain/app/pages/not-found/app-not-found-page.composable'

  definePageMeta({
    middleware: ['app-not-found-page-middleware'],
  })

  useAppNotFoundPage()
</script>

<template>
  <div />
</template>

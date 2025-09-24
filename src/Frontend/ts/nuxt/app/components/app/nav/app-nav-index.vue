<script setup lang="ts">
  import { useAppNavIndexComponent } from '~/utils/domain/app/components/nav/index/app-nav-index-component.composable'
  import type { AppNavItemsComponentInput } from '~/utils/domain/app/components/nav/items/app-nav-items-component.types'

  const { items } = useAppNavIndexComponent()

  const itemsComponentInput = {
    items,
  } as AppNavItemsComponentInput
</script>

<template>
  <nav class="app-nav">
    <AppNavItems v-bind="itemsComponentInput" />
  </nav>
</template>
